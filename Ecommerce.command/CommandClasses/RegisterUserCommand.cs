using MediatR;
using Ecommerce.Domain.Respoances;
using Ecommerce.Domain.DBClasses;
using Ecommerce.Domain.DTO_Classes;

namespace Ecommerce.command.CommandClasses
{
    public class RegisterUserCommand : IRequest<UserRespoance>
    {
        public UserProperties RegisterUservalues { get; set; }

        public RegisterUserCommand(UserProperties user)
        {
            RegisterUservalues = user;
        }

    }
}
