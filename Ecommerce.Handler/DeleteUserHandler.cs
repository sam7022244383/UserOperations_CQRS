using Ecommerce.command.CommandClasses;
using Ecommerce.DataProvider.BusinessLogic.Interfaces;
using Ecommerce.Domain.Respoances;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Handler
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand , UserRespoance>
    {
        private readonly ILoginInterface _loginInterface;

        public DeleteUserHandler(ILoginInterface loginInterface)
        {
            _loginInterface = loginInterface;
        }

        public async Task<UserRespoance> Handle(DeleteUserCommand command , CancellationToken cancellationToken)
        {
            return await _loginInterface.DeleteUser(command._ID);
        }

    }
}
