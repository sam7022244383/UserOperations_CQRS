using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Ecommerce.Mapper;


namespace Ecommerce.Handler.ConfigureServices
{
    public class ConfigureServicesAction
    {
        public static void Execute(IServiceCollection services)
        {
            services.AddMediatR(typeof(Ecommerce.Handler.GetIDHandler).Assembly);
            services.AddAutoMapper(typeof(MappliProfile));

        }
    }
}
