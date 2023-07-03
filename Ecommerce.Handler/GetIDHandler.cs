using MediatR;
using Ecommerce.DataProvider.BusinessLogic.Interfaces;
using Ecommerce.DataProvider.BusinessLogic.Implementation;
using Ecommerce.Query;


namespace Ecommerce.Handler
{
    public class GetIDHandler : IRequestHandler<GetIDQuery, int>
    {
        private readonly Itest _test; 
        public GetIDHandler(Itest test) 
        {
           _test = test;
        }

        public async Task<int> Handle(GetIDQuery query , CancellationToken cancellationToken)
        {
            return await _test.getid(query.ID);
        }
    }
}
