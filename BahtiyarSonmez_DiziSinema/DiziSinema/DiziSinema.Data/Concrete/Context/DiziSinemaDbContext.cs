using DiziSinema.Data.Concrete.Configs;
using DiziSinema.Entity.Concrete.Entitys;
using DiziSinema.Entity.Concrete.JunctionClasses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiziSinema.Data.Concrete.Context
{
    public class DiziSinemaDbContext:DbContext
    {
        public DiziSinemaDbContext(DbContextOptions options):base(options)
        {
            
        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<SerialTv> SerialTvs { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<MovieGenre> MovieGenres { get; set; }
        public DbSet<SerialTvGenre> SerialTvGenres { get; set;}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GenreConfig).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
