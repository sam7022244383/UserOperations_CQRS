using Ecommerce.DataProvider.BusinessLogic.Interfaces;
using Ecommerce.Domain.DTO_Classes;
using Ecommerce.Domain.Respoances;
using Ecommerce.Query;
using MediatR;

namespace Ecommerce.Handler
{
    public class LoginHandler : IRequestHandler<LoginQuery, LoginRespoance>
    {
        private readonly ILoginInterface _loginInterface; 

        public LoginHandler(ILoginInterface loginInterface)
        {
            _loginInterface = loginInterface;
        }

        public async Task<LoginRespoance> Handle(LoginQuery loginProperties , CancellationToken cancellationToken)
        {
            return await _loginInterface.LoginUser(loginProperties.EmailAddress , loginProperties.Password);
        }
    }
}
