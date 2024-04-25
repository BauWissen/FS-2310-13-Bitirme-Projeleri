using CosmeticShop.Data.Concrete.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CosmeticShop.UI.Extensions
{
    public static class HostServiceExtension
    {
        public static IHost UpdateDatabase(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                using (var cosmeticShopDbContext = scope.ServiceProvider.GetRequiredService<CosmeticShopDbContext>())
                {
                    try
                    {
                        var pendingMigrationCount = cosmeticShopDbContext.Database.GetPendingMigrations().Count();
                        if (pendingMigrationCount > 0)
                            cosmeticShopDbContext.Database.Migrate();
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
}
