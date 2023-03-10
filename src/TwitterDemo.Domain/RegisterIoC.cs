using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace TwitterDemo.Domain
{
    public static class RegisterIoC
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());            

            return services;
        }
    }
}
