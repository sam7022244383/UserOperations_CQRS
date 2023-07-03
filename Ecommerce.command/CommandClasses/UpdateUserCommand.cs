using Ecommerce.Domain.DTO_Classes;
using Ecommerce.Domain.Respoances;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Ecommerce.command.CommandClasses
{
    public class UpdateUserCommand : IRequest<UserRespoance>
    {

        public int ID { get; set; }
        public JsonPatchDocument Testmodel { get; }

        public UpdateUserCommand(JsonPatchDocument user, int iD)
        {
            Testmodel = user;
            ID = iD;
        }

    }
}
