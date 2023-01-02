using Microsoft.Extensions.DependencyInjection;
using TwitterDemo.Domain;

namespace TwitterDemo.Infra.IoC
{
    public static class IoCWrapper
    {
        public static IServiceCollection AddDependencyInjectionForAllLayers(this IServiceCollection services)
        {
            services.AddDomainServices();

            return services;
        }
    }
}
