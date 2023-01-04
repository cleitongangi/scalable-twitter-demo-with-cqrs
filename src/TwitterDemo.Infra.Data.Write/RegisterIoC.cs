using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Debug;
using System.Reflection;
using TwitterDemo.Domain.Interfaces.Data;
using TwitterDemo.Infra.Data.Write.Context;

namespace TwitterDemo.Infra.Data.Write
{
    public static class RegisterIoC
    {
        public static readonly LoggerFactory MyLoggerFactory = new(new[] { new DebugLoggerProvider() });

        public static IServiceCollection AddDataWriteServices(this IServiceCollection services, string writeDbCnnString)
        {
            #region Register DBContext            
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<WriteDbContext>();

            services.AddDbContext<WriteDbContext>(options =>
            {
                options
                    .UseNpgsql(writeDbCnnString)
                    .UseSnakeCaseNamingConvention()
                    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                    .UseLoggerFactory(MyLoggerFactory);
            });
            #endregion Register DBContext


            #region Register all repositories
            //var repositoriesAssembly = typeof(UserRepository).Assembly;
            //var repositoriesRegistrations =
            //    from type in repositoriesAssembly.GetExportedTypes()
            //    where type.Namespace == "TwitterDemo.Infra.Data.Write.Repositories"
            //    where type.GetInterfaces().Any()
            //    select new { Interface = type.GetInterfaces().FirstOrDefault(), Implementation = type };

            //foreach (var reg in repositoriesRegistrations)
            //    services.AddScoped(reg.Interface, reg.Implementation);
            #endregion Register all repositories

            return services;
        }
    }
}
