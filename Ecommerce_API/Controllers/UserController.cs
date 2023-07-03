using Microsoft.AspNetCore.Mvc;
using MediatR;
using Ecommerce.Query;
using Ecommerce.Domain.DTO_Classes;
using Ecommerce.command.CommandClasses;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using Microsoft.AspNetCore.JsonPatch;

namespace Ecommerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

       private readonly IMediator _mediator;
        private readonly ILogger _logger;

        public UserController(IMediator mediator, ILogger<UserController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterUser([FromBody] UserProperties userProperties)
        {
          _logger.LogInformation("RegisterUser", userProperties.Email, userProperties.FirstName);
          return Ok(await _mediator.Send(new RegisterUserCommand(userProperties)));
           

        }

        [HttpGet("login")]
        [AllowAnonymous]
        public async Task<IActionResult> LoginUser([FromHeader] string EmailAddress , [FromHeader] string Password)
        {
            _logger.LogInformation("LoginUser", EmailAddress, Password);
            var result =  await _mediator.Send(new LoginQuery() { EmailAddress = EmailAddress, Password = Password });
            return Ok(JsonConvert.SerializeObject(result));
        }

        [HttpDelete("delete")]
        [AllowAnonymous]
        public async Task<IActionResult> DeleteUser([FromHeader] int ID)
        {
            _logger.LogInformation("DeleteUser : ", ID);
           return Ok(await _mediator.Send(new  DeleteUserCommand(ID)));

        }

        [HttpPatch("Update/{id}")]
        public async Task<IActionResult> UpdateDataPatch(int id, [FromBody] JsonPatchDocument testmodel)
        {

            return Ok(await _mediator.Send(new UpdateUserCommand(testmodel, id)));
        }


        [HttpGet("{id}")]
        public async Task<int> GetID(int id)
        {
            var query = new GetIDQuery {ID=id};
            return await _mediator.Send(query);

        }
    }
}
