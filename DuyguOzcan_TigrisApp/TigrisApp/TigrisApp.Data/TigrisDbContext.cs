using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TigrisApp.Entity.Concrete;
using TigrisApp.Entity.Concrete.Identity;

namespace TigrisApp.Data
{
    public class TigrisDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public TigrisDbContext(DbContextOptions<TigrisDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Colour> Colors { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductGender> ProductGenders { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            #region Category
            builder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Name = "Kolye",
                    Description = "kolye"
                },
                new Category
                {
                    Id = 2,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Name = "Yüzük",
                    Description = "yüzük"
                },
                new Category
                {
                    Id = 3,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Name = "Bileklik",
                    Description = "bileklik"
                },
                new Category
                {
                    Id = 4,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Name = "Küpe",
                    Description = "küpe"
                }

            );

            #endregion
            #region Gender
            builder.Entity<Gender>().HasData(
                new Gender
                {
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Id = 1,
                    Name = "Kadın"

                },
                 new Gender
                 {
                     CreatedDate = DateTime.Now,
                     ModifiedDate = DateTime.Now,
                     Id = 2,
                     Name = "Erkek"

                 }
            );
            #endregion
            #region Colour
            builder.Entity<Colour>().HasData(
                new Colour
                {
                    Id = 1,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Name = "Silver"
                },
                new Colour
                {
                    Id = 2,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Name = "Gold"

                }
            );
            #endregion
            #region Region
            builder.Entity<Region>().HasData(
                new Region
                {
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Id = 1,
                    Name = "Türkiye"
                },
                new Region
                {
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Id = 2,
                    Name = "Çin"
                },
                new Region
                {
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Id = 3,
                    Name = "Malezya"
                }

            );

            #endregion

            #region Supplier
            builder.Entity<Supplier>().HasData(
                new Supplier
                {
                    Id = 1,
                    Name = "Supplier1",
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    RegionId = 1
                },
                new Supplier
                {
                    Id = 2,
                    Name = "Supplier2",
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    RegionId = 2
                }
            );
            #endregion
            #region Material
            builder.Entity<Material>().HasData(
                new Material
                {
                    Id = 1,
                    Name = "Çelik",
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Description = "çelik"
                },
                new Material
                {
                    Id = 2,
                    Name = "Zirkon",
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Description = "zirkon"
                }
            );
            #endregion

            #region Basket
            builder.Entity<Basket>().HasData(
                new Basket
                {
                    UserId = 1,
                    Id = 1
                }
            );

            #endregion
            #region BasketItem
            builder.Entity<BasketItem>().HasData(
                new BasketItem
                {
                    Id = 1,
                    BasketId = 1,
                    ProductId = 1,
                    Quantity = 2
                }
            );

            #endregion
            #region Cusomer
            builder.Entity<Customer>().HasData(
                new Customer
                {
                    Id = 1,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                     
                },
                 new Customer
                 {
                     Id = 2,
                     CreatedDate = DateTime.Now,
                     ModifiedDate = DateTime.Now
                 }

            );

            #endregion

            #region Product
            builder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Amount = 2,
                    CategoryId = 1,
                    ColourId = 1,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    MaterialId = 1,
                    SupplierId = 1,
                    IsActive = true,
                    Name = "halka küpe",
                    Price = 1000
                },
                new Product
                {
                    Id = 2,
                    Amount = 3,
                    CategoryId = 1,
                    ColourId = 2,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    MaterialId = 1,
                    SupplierId = 1,
                    IsActive = true,
                    Name = "çelik kolye",
                    Price = 1000
                },
                new Product
                {
                    Id = 3,
                    Amount = 4,
                    CategoryId = 2,
                    ColourId = 2,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    MaterialId = 2,
                    SupplierId = 1,
                    IsActive = true,
                    Name = "çelik yüzük",
                    Price = 4000
                },
                new Product
                {
                    Id = 4,
                    Amount = 2,
                    CategoryId = 2,
                    ColourId = 2,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    MaterialId = 1,
                    SupplierId = 1,
                    IsActive = true,
                    Name = "taşlı yüzük",
                    Price = 600
                }
            );

            #endregion
            #region Order
            builder.Entity<Order>().HasData(
                new Order
                {
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Id = 1,
                    Name = "order1"
                },
                new Order
                {
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Id = 2,
                    Name = "order2"
                },
                new Order
                {
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Id = 3,
                    Name = "order2"
                }
            );
            #endregion
            #region OrderDetail
            builder.Entity<OrderDetail>().HasData(
                new OrderDetail
                {
                    Id=1,
                    ProductId = 1,
                    ProductPrice = 1000,
                    Quantity = 1
                },
                new OrderDetail
                {
                    Id=2,
                    ProductId = 2,
                    ProductPrice = 2000,
                    Quantity = 1
                },
                new OrderDetail
                {
                    Id = 3,
                    ProductId = 3,
                    ProductPrice = 4000,
                    Quantity = 1
                }
            );
            #endregion

            #region ProductGender
            builder.Entity<ProductGender>().HasData(
                new ProductGender
                {
                    Id = 1,
                    ProductId = 1,
                    GenderId = 1
                },
                new ProductGender
                {
                    Id = 2,
                    ProductId = 1,
                    GenderId = 2
                },
                new ProductGender
                {
                    Id = 3,
                    ProductId = 2,
                    GenderId = 1
                },
                new ProductGender
                {
                    Id = 4,
                    ProductId = 2,
                    GenderId = 2
                },
                new ProductGender
                {
                    Id = 5,
                    ProductId = 3,
                    GenderId = 1
                },
                new ProductGender
                {
                    Id = 6,
                    ProductId = 4,
                    GenderId = 2
                }

            );
            #endregion



            base.OnModelCreating(builder);

        }
    }
}