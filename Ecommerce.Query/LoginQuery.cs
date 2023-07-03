using MediatR;
using Ecommerce.Domain;
using Ecommerce.Domain.Respoances;

namespace Ecommerce.Query
{
    public class LoginQuery : IRequest<LoginRespoance>
    {
        public string EmailAddress { get; set; }   

        public string Password { get; set; }
    }
}
