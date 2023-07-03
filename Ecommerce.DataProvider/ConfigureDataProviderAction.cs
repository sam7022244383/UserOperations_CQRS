using Microsoft.Extensions.DependencyInjection;
using Ecommerce.DataProvider.BusinessLogic.Implementation;
using Ecommerce.DataProvider.BusinessLogic.Interfaces;


namespace Ecommerce.DataProvider
{
    public class ConfigureDataProviderAction
    {
        public static void Execute(IServiceCollection service )
        {
            service.AddTransient<Itest, testclass>();
            service.AddTransient<ILoginInterface , LoginOperations>();
        }
    }
}
