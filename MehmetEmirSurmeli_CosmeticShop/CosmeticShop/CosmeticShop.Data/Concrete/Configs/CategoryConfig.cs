using CosmeticShop.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmeticShop.Data.Concrete.Configs
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(c => c.Id);
            entityTypeBuilder.Property(c => c.Id).ValueGeneratedOnAdd();
            entityTypeBuilder.Property(c => c.Name).IsRequired().HasMaxLength(50);
            entityTypeBuilder.Property(c => c.CategoryDescription).IsRequired().HasMaxLength(500);
            entityTypeBuilder.Property(c => c.Url).IsRequired().HasMaxLength(50);

            entityTypeBuilder.ToTable("Categories");
            entityTypeBuilder.HasData(

                new Category
                {
                    Id = 1,
                    Name = "Parfüm",
                    CategoryDescription = "Parfüm Kategorisi",
                    Url = "parfum"
                },
                new Category
                {
                    Id = 2,
                    Name = "Ruj",
                    CategoryDescription = "Ruj Kategorisi",
                    Url = "ruj"
                },
                new Category
                {
                    Id = 3,
                    Name = "Oje",
                    CategoryDescription = "Oje Kategorisi",
                    Url = "oje"
                },
                new Category
                {
                    Id = 4,
                    Name = "Krem",
                    CategoryDescription = "Krem Kategorisi",
                    Url = "krem"
                },
                new Category
                {
                    Id = 5,
                    Name = "Göz Makyajı",
                    CategoryDescription = "Göz Makyajı Kategorisi",
                    Url = "goz-makyaji"
                }

                );
        }
    }
}
