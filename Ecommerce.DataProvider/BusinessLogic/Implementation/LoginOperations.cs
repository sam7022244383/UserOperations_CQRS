using Ecommerce.DataProvider.BusinessLogic.Interfaces;
using Ecommerce.Domain.DTO_Classes;
using Ecommerce.Domain.Respoances;
using Microsoft.EntityFrameworkCore;
using Ecommerce.Domain.DBClasses;
using Microsoft.Extensions.Logging;
using Ecommerce.DataProvider.JWT_Operations;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.JsonPatch;
using System.Text.Json;

namespace Ecommerce.DataProvider.BusinessLogic.Implementation
{
    public class LoginOperations : ILoginInterface
    {
        private readonly AppDBContext _appContext;
        private readonly ILogger<LoginOperations> _logger;
        private readonly IConfiguration _config;

        public LoginOperations(AppDBContext appContext, ILogger<LoginOperations> logger, IConfiguration config)
        {
            _appContext = appContext;
            _logger = logger;
            _config = config;
            _logger.LogInformation("Inside LoginOperations");
        }

        public async Task<UserRespoance> DeleteUser(int ID)
        {
            var result = await _appContext.registerUsers.Where(x=> x.UserId == ID).FirstOrDefaultAsync();
            if(result == null)
            {
                return new UserRespoance() { ErrorMessage = "User with ID : " + ID + " Does not exists" };
            }
            result.Address = await _appContext.registerUsersAddress.Where(x => x.RegisterUserAddress_ID == ID).FirstOrDefaultAsync();
            _appContext.Entry(result).State = EntityState.Deleted;
            await _appContext.SaveChangesAsync();
            return new UserRespoance() { SuccessMessage = "User with ID : " + ID + " Deleted Successfully" };

        }

        public async Task<LoginRespoance> LoginUser(string Email, string password)
        {
            var loginrespoance = new LoginRespoance();
            var Logindata = _appContext.registerUsers.Where(x => x.Email == Email && x.Password == password).FirstOrDefault();
            _logger.LogInformation("DB Login Data : ", Logindata);
            if (Logindata == null) { return new LoginRespoance() { _LoginErrorMsg = "Password or Email is Inccorect" }; }
                var val = new JwtService(_config).GenerateToken(
                            Logindata.UserId.ToString(),
                            Logindata.FirstName,
                            Logindata.LastName,
                            Logindata.Email
                            );
                return new LoginRespoance()
                {
                    _email = Email,
                    Token = new JwtSecurityTokenHandler().WriteToken(val),
                    _tokenexpirationdate = TimeZoneInfo.ConvertTimeFromUtc(val.ValidTo, TimeZoneInfo.FindSystemTimeZoneById("India Standard Time")),
                };


        }

        public async Task<UserRespoance> RegisterUser(UserProperties userProperties)
        {
            _logger.LogInformation("Inside RegisterUser");
            if ( _appContext.registerUsers.Where(e => e.Email == userProperties.Email).FirstOrDefaultAsync() != null)
            {
                return new UserRespoance() { ErrorMessage = "User with Email ID :"+userProperties.Email +" Already Exists"};
            
            }

            RegisterUser _user = new RegisterUser()
            {
                FirstName = userProperties.FirstName,
                LastName = userProperties.LastName,
                Email = userProperties.Email,
                Password = userProperties.Password,
                IsActive = true,
                registeredOn = DateTime.Now,
                ForgetCode = userProperties.ForgetCode,
                Address = new RegisterUserAddress()
                {
                    RegisterUserAddress_country = userProperties.RegisterUserAddress_country,
                    RegisterUserAddress_state = userProperties.RegisterUserAddress_state,
                    RegisterUserAddress_city = userProperties.RegisterUserAddress_city,
                    RegisterUserAddress_PostalCode = userProperties.RegisterUserAddress_PostalCode,
                    RegisterUserAddress_PhoneNumber = userProperties.RegisterUserAddress_PhoneNumber
                }

            };
            _appContext.registerUsers.AddAsync(_user);
            _appContext.SaveChangesAsync();
            return new UserRespoance() { SuccessMessage = "Account with the Email Address : "+userProperties.Email+"Has been Successfully Created"};
            
        }

        public async Task<UserRespoance> UpdateDataPatch(int iD, Microsoft.AspNetCore.JsonPatch.JsonPatchDocument user)
        {
            var modeldata = await _appContext.registerUsers.FindAsync(iD); //To check whether data is available or not
            if (modeldata != null)
            {
                user.ApplyTo(modeldata);
                await _appContext.SaveChangesAsync();
                return new UserRespoance() { SuccessMessage = "Updated the user" };
            }
            else
            {
                return new UserRespoance() { ErrorMessage = "User does not exists to update" };
            }
        }
    }
}
