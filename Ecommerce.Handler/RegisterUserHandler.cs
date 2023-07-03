using MediatR;
using Ecommerce.command.CommandClasses;
using Ecommerce.Domain.Respoances;
using Ecommerce.DataProvider.BusinessLogic.Interfaces;

namespace Ecommerce.Handler
{
    public class RegisterUserHandler :IRequestHandler<RegisterUserCommand , UserRespoance>
    {

        private readonly ILoginInterface _loginInterface;

        public RegisterUserHandler(ILoginInterface loginInterface)
        {
            _loginInterface = loginInterface;
        }

        public async Task<UserRespoance> Handle(RegisterUserCommand command ,CancellationToken cancellationToken)
        {
            return await _loginInterface.RegisterUser(command.RegisterUservalues);
        }
    }
}
