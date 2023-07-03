using Ecommerce.command.CommandClasses;
using Ecommerce.DataProvider.BusinessLogic.Interfaces;
using Ecommerce.Domain.Respoances;
using Ecommerce.DataProvider.BusinessLogic.Implementation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Handler
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand , UserRespoance>
    {
        private readonly ILoginInterface _loginInterface;

        public UpdateUserHandler(ILoginInterface loginInterface)
        {
            _loginInterface = loginInterface;
        }

        public async Task<UserRespoance> Handle(UpdateUserCommand updateUserCommand, CancellationToken cancellationToken)
        {
            return await _loginInterface.UpdateDataPatch(updateUserCommand.ID, updateUserCommand.Testmodel);
        }

    }
}
