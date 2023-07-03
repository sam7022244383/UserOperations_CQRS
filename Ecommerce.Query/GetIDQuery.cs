using MediatR;

namespace Ecommerce.Query
{
    public class GetIDQuery : IRequest<int>
    {
        public int ID { get; set; }
    }
}
