using DiziSinema.MVC.Extensions;
using DiziSinema.MVC.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace DiziSinema.MVC.Dal
{
    public class Db:IdentityDbContext<User,Role,string>
    {
        public Db(DbContextOptions options):base(options) 
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.SeedData();
            base.OnModelCreating(modelBuilder);
        }
    }
}
