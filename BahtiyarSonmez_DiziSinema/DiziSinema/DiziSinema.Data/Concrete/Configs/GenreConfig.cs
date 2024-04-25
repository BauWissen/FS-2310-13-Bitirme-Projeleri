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
    public class GenreConfig : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.GenreName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(500);
            builder.Property(x => x.Url).IsRequired().HasMaxLength(60);
            builder.ToTable("Genres");
            builder.HasData(
                new Genre
                {
                    Id = 1,
                    GenreName = "Korku",
                    Description = "korku Kategorisi",
                    Url = "korku"
                },
                new Genre
                {
                    Id = 2,
                    GenreName = "Romantik",
                    Description = "Romantik Kategorisi",
                    Url = "dram"
                },
                new Genre
                {
                    Id = 3,
                    GenreName = "Komedi",
                    Description = "Komedi Kategorisi",
                    Url = "komedi"
                },
                new Genre
                {
                    Id = 4,
                    GenreName = "Bilim Kurgu",
                    Description = "Bilim Kurgu Kategorisi",
                    Url = "bilim-kurgu"
                },
                new Genre
                {
                    Id = 5,
                    GenreName = "Anime",
                    Description = "Anime Kategorisi",
                    Url = "anime"
                });
        }
    }
}
