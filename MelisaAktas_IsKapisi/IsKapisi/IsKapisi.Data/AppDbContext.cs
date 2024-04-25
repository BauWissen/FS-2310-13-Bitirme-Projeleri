using IsKapisi.Data.Config;
using IsKapisi.Entity;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IsKapisi.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Job> Jobs { get; set; }

        public DbSet<CategoryJob> CategoryJobs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryConfig());
            modelBuilder.ApplyConfiguration(new  JobConfig());
            modelBuilder.ApplyConfiguration(new CategoryJobConfig());

            base.OnModelCreating(modelBuilder);

         

        }
    }
}
