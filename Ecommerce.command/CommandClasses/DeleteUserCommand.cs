using Ecommerce.Domain.Respoances;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.command.CommandClasses
{
    public class DeleteUserCommand : IRequest<UserRespoance>
    {
        public int _ID { get; set; }

        public DeleteUserCommand(int ID)
        {
            _ID = ID;
        }
    }
}
