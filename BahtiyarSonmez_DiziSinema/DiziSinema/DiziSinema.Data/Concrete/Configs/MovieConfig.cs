using DiziSinema.Entity.Concrete.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiziSinema.Data.Concrete.Configs
{
    public class MovieConfig : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).ValueGeneratedOnAdd();

            builder.Property(m => m.MovName).IsRequired().HasMaxLength(60);
            builder.Property(m => m.MovIntro).IsRequired().HasMaxLength(500);
            builder.Property(m => m.MovLanguage).IsRequired().HasMaxLength(60);
            builder.Property(m => m.Url).IsRequired().HasMaxLength(80);
            builder.Property(m => m.ImageUrl).IsRequired().HasMaxLength(80);
            builder.Property(s => s.CreatedDate).HasDefaultValueSql("Data('now')");
            builder.Property(s => s.ModifiedDate).HasDefaultValueSql("Data('now')");
            builder.ToTable("Movies");
            builder.HasData(
                new Movie
                {
                    Id = 1,
                    MovName = "Film1",
                    MovIntro = "Title",
                    MovLanguage = "türkce dublaj",
                    Url = "film-1",
                    ImageUrl = "1.jpg",
                    IsActive = true,
                    IsDeleted = false
                },
                new Movie
                {
                    Id = 2,
                    MovName = "Film2",
                    MovIntro = "Title",
                    MovLanguage = "türkce dublaj",
                    Url = "film-2",
                    ImageUrl = "2.jpg",
                    IsActive = true,
                    IsDeleted = false
                },
                new Movie
                {
                    Id = 3,
                    MovName = "Film3",
                    MovIntro = "Title",
                    MovLanguage = "türkce dublaj",
                    Url = "film-3",
                    ImageUrl = "3.jpg",
                    IsActive = true,
                    IsDeleted = false
                },
                new Movie
                {
                    Id = 4,
                    MovName = "Film4",
                    MovIntro = "Title",
                    MovLanguage = "türkce dublaj",
                    Url = "film-4",
                    ImageUrl = "4.jpg",
                    IsActive = true,
                    IsDeleted = false
                },
                new Movie
                {
                    Id = 5,
                    MovName = "Film5",
                    MovIntro = "Title",
                    MovLanguage = "türkce dublaj",
                    Url = "film-5",
                    ImageUrl = "5.jpg",
                    IsActive = true,
                    IsDeleted = false
                },
                new Movie
                {
                    Id = 6,
                    MovName = "Film6",
                    MovIntro = "Title",
                    MovLanguage = "türkce dublaj",
                    Url = "film-6",
                    ImageUrl = "6.jpg",
                    IsActive = true,
                    IsDeleted = false
                }
                );
        }
    }
}
