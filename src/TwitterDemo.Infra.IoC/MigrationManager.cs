using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TwitterDemo.Infra.Data.Write.Context;

namespace TwitterDemo.Infra.IoC
{
    public static class MigrationManager
    {
        public static void ApplyMigration(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            using var appContext = scope.ServiceProvider.GetRequiredService<WriteDbContext>();
            appContext.Database.Migrate();
        }
    }
}
