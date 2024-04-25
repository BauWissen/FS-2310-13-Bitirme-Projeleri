using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SalesUp.Data.Concrete.Configs;
using SalesUp.Data.Extensions;
using SalesUp.Entity;
using SalesUp.Entity.Identity;

namespace SalesUp.Data.Concrete.Contexts;

public class SalesUpDbContext:IdentityDbContext<User, Role, string>
{
    public SalesUpDbContext(DbContextOptions options) : base(options)
    {
        
    }
    public DbSet<Product> Products { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<STask> Tasks { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<Sale> Sales { get; set; }
    public DbSet<Subscription> Subscriptions { get; set; }
    public DbSet<ContactUs> Contacts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.SeedData();
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SubscriptionConfig).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}


