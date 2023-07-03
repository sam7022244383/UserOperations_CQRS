

using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Ecommerce.DataProvider.JWT_Operations
{
    public class JwtService
    {
        public string Secretkey { get; set; }

        public int TokenDuration { get; set; }

        private readonly IConfiguration _config;

        public JwtService(IConfiguration config)
        {
            _config = config;
            this.Secretkey = _config.GetSection("jwtconfig").GetSection("key").Value;
            this.TokenDuration = Int32.Parse(_config.GetSection("jwtconfig").GetSection("Duration").Value);
        }

        public JwtSecurityToken GenerateToken(string id, string firstname, string lastname, string email)
        {
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(this.Secretkey));
            var signature = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var payload = new[]
            {
                new Claim("id",id),
                new Claim("firstname",firstname),
                new Claim("lastname",lastname),
                new Claim("email",email)
            };

            var jwttoken = new JwtSecurityToken(
                  issuer: "localhost",
                  audience: "localhost",
                  claims: payload,
                  expires: DateTime.Now.AddMinutes(TokenDuration),
                  signingCredentials: signature
                );
            // return new JwtSecurityTokenHandler().WriteToken(jwttoken);
            return jwttoken;

        }
    }
}
