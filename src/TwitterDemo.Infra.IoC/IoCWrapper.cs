using Microsoft.Extensions.DependencyInjection;
using TwitterDemo.Domain;
using TwitterDemo.Infra.Data.Write;

namespace TwitterDemo.Infra.IoC
{
    public static class IoCWrapper
    {
        public static IServiceCollection AddDependencyInjectionForAllLayers(this IServiceCollection services, string writeDbConnectionString)
        {
            services.AddDomainServices();
            services.AddDataWriteServices(writeDbConnectionString);

            return services;
        }
    }
}
