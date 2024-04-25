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
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(p => p.Id);
            entityTypeBuilder.Property(p => p.Id).ValueGeneratedOnAdd();

            entityTypeBuilder.Property(p => p.Name).IsRequired().HasMaxLength(100);
            entityTypeBuilder.Property(p => p.Properties).IsRequired().HasMaxLength(500);
            entityTypeBuilder.Property(p => p.Url).IsRequired().HasMaxLength(100);
            entityTypeBuilder.Property(p => p.ImageUrl).IsRequired().HasMaxLength(500);
            entityTypeBuilder.Property(p => p.Price).IsRequired().HasColumnType("real"); 
            entityTypeBuilder.Property(p => p.CreatedDate).HasDefaultValueSql("date('now')"); 
            entityTypeBuilder.Property(p => p.ModifiedDate).HasDefaultValueSql("date('now')"); 
            entityTypeBuilder.ToTable("Products");
            entityTypeBuilder.HasData(
                new Product
                {
                    Id = 1,
                    Name = "Diorm Sauvage EDP",
                    Price = 13000,
                    Properties = "Mükemmel bir parfüm",
                    Url = "dior-sauvage",
                    ImageUrl = "1.png",
                    IsHome = true
                },
                new Product
                {
                    Id = 2,
                    Name = "Avon Full Speed",
                    Price = 69000,
                    Properties = "Mükemmel parfüm",
                    Url = "avon-full-speed",
                    ImageUrl = "2.png",
                    IsHome = false
                },
                new Product
                {
                    Id = 3,
                    Name = "Tom Ford Bois Marocain Eau de Parfum 250 Ml",
                    Price = 29000,
                    Properties = "İdare eder",
                    Url = "tom-ford-bois-marocain",
                    ImageUrl = "3.png",
                    IsHome = true
                },
                new Product
                {
                    Id = 4,
                    Name = "Givenchy Gentleman Boisee Eau de Parfum EDP 200 Ml",
                    Price = 39000,
                    Properties = "Harika bir parfüm",
                    Url = "givenchy-gentlemen-boisee",
                    ImageUrl = "4.png",
                    IsHome = true
                },
                new Product
                {
                    Id = 5,
                    Name = "Dior Fahrenheit / Erkek Parfüm",
                    Price = 52000,
                    Properties = "Harika bir parfüm",
                    Url = "dior-fahrenheit",
                    ImageUrl = "5.png",
                    IsHome = true
                },
                new Product
                {
                    Id = 6,
                    Name = "Blvgari BVLGARI Man Wood Essence - Eau de Parfum 150ml",
                    Price = 79000,
                    Properties = "harika bir parfüm",
                    Url = "blvgari-man-vood",
                    ImageUrl = "6.png",
                    IsHome = false
                },
                new Product
                {
                    Id = 7,
                    Name = "Creed Aventus Edp 100 ml Erkek Parfüm",
                    Price = 19000,
                    Properties = "harika bir parfüm",
                    Url = "creed-aventus-edp",
                    ImageUrl = "7.png",
                    IsHome = true
                },
                new Product
                {
                    Id = 8,
                    Name = "Parfums De Marly Pegasus Exclusif Edp 125 ml",
                    Price = 21000,
                    Properties = "Süper bir parfüm",
                    Url = "parfums-de-marly-pegasus",
                    ImageUrl = "8.png",
                    IsHome = false
                },
                new Product
                {
                    Id = 9,
                    Name = "Tom Ford Tobacco Vanille Eau de Parfum 50 Ml",
                    Price = 1250,
                    Properties = "Klasik sevenler için",
                    Url = "tom-ford-tobacco-vanille",
                    ImageUrl = "9.png",
                    IsHome = true
                },
                new Product
                {
                    Id = 10,
                    Name = "Spice Bomb Extreme",
                    Price = 2100,
                    Properties = "Dayanılmaz koku",
                    Url = "spice-bomb-extreme",
                    ImageUrl = "10.png",
                    IsHome = true
                },
                new Product
                {
                    Id = 11,
                    Name = "Paco Rabanne Invictus EDT Erkek Parfüm, 100 ml",
                    Price = 9800,
                    Properties = "Dünya klasiği dayanılmaz koku",
                    Url = "paco-rabanne-invictus",
                    ImageUrl = "11.png",
                    IsHome = true
                });
        }
    }
}
