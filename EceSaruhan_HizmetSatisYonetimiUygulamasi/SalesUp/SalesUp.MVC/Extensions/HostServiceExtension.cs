using Microsoft.EntityFrameworkCore;
using SalesUp.Data.Concrete.Contexts;

namespace SalesUp.MVC.Extensions;

public static class HostServiceExtension
{
    public static IHost UpdateDatabase(this IHost host)
    {
        using (var scope = host.Services.CreateScope())
        {
            using (var salesUpDbContext = scope.ServiceProvider.GetRequiredService<SalesUpDbContext>())
            {
                try
                {
                    var pendingMigrationCount = salesUpDbContext.Database.GetPendingMigrations().Count();
                    if (pendingMigrationCount > 0)
                        salesUpDbContext.Database.Migrate();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    throw;
                }
            }
        }
        return host;
    }
}