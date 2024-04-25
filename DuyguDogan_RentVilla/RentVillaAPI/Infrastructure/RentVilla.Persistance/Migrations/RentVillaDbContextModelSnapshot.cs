﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RentVilla.Persistance.Contexts;

#nullable disable

namespace RentVilla.Persistence.Migrations
{
    [DbContext(typeof(RentVillaDbContext))]
    partial class RentVillaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.17");

            modelBuilder.Entity("AppRoleEndpoint", b =>
                {
                    b.Property<string>("EndpointsId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RolesId")
                        .HasColumnType("TEXT");

                    b.HasKey("EndpointsId", "RolesId");

                    b.HasIndex("RolesId");

                    b.ToTable("AppRoleEndpoint");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("ProductProductImageFile", b =>
                {
                    b.Property<string>("ProductId")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProductImageFilesId")
                        .HasColumnType("TEXT");

                    b.HasKey("ProductId", "ProductImageFilesId");

                    b.HasIndex("ProductImageFilesId");

                    b.ToTable("ProductProductImageFile");
                });

            modelBuilder.Entity("RentVilla.Domain.Entities.Concrete.Attribute.AttributeType", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("AttributeTypes");
                });

            modelBuilder.Entity("RentVilla.Domain.Entities.Concrete.Attribute.Attributes", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("AttributeTypeId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("AttributeTypeId");

                    b.ToTable("Attributes");
                });

            modelBuilder.Entity("RentVilla.Domain.Entities.Concrete.Attribute.ProductAttribute", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("AttributeTypeId")
                        .HasColumnType("TEXT");

                    b.Property<string>("AttributesId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProductId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AttributeTypeId");

                    b.HasIndex("AttributesId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductAttributes");
                });

            modelBuilder.Entity("RentVilla.Domain.Entities.Concrete.Cart.ReservationCart", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("ReservationCarts");
                });

            modelBuilder.Entity("RentVilla.Domain.Entities.Concrete.Cart.ReservationCartItem", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AdultNumber")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ChildrenNumber")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Note")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProductId")
                        .HasColumnType("TEXT");

                    b.Property<double>("ProductPrice")
                        .HasColumnType("REAL");

                    b.Property<string>("ReservationCartId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("TEXT");

                    b.Property<double>("TotalCost")
                        .HasColumnType("REAL");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("ReservationCartId");

                    b.ToTable("ReservationCartItems");
                });

            modelBuilder.Entity("RentVilla.Domain.Entities.Concrete.Endpoint", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ActionType")
                        .HasColumnType("TEXT");

                    b.Property<string>("Code")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Definition")
                        .HasColumnType("TEXT");

                    b.Property<string>("HttpType")
                        .HasColumnType("TEXT");

                    b.Property<string>("MenuId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("MenuId");

                    b.ToTable("Endpoints");
                });

            modelBuilder.Entity("RentVilla.Domain.Entities.Concrete.File", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FileName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Path")
                        .HasColumnType("TEXT");

                    b.Property<string>("Storage")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Files");

                    b.HasDiscriminator<string>("Discriminator").HasValue("File");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("RentVilla.Domain.Entities.Concrete.Identity.AppRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("RentVilla.Domain.Entities.Concrete.Identity.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Gender")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ProfileImage")
                        .HasColumnType("TEXT");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("RefreshTokenEndDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("RentVilla.Domain.Entities.Concrete.Menu", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Menus");
                });

            modelBuilder.Entity("RentVilla.Domain.Entities.Concrete.Product", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValueSql("now()");

                    b.Property<double>("Deposit")
                        .HasColumnType("REAL");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("MapId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<double>("Price")
                        .HasColumnType("double");

                    b.Property<string>("Properties")
                        .HasColumnType("TEXT");

                    b.Property<string>("Rating")
                        .HasColumnType("TEXT");

                    b.Property<int>("ShortestRentPeriod")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValueSql("now()");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("RentVilla.Domain.Entities.Concrete.Region.City", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("StateId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("StateId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("RentVilla.Domain.Entities.Concrete.Region.Country", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("RentVilla.Domain.Entities.Concrete.Region.District", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("CityId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Districts");
                });

            modelBuilder.Entity("RentVilla.Domain.Entities.Concrete.Region.ProductAddress", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("CityId")
                        .HasColumnType("TEXT");

                    b.Property<string>("CountryId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("DistrictId")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProductId")
                        .HasColumnType("TEXT");

                    b.Property<string>("StateId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("CountryId");

                    b.HasIndex("DistrictId");

                    b.HasIndex("ProductId")
                        .IsUnique();

                    b.HasIndex("StateId");

                    b.ToTable("ProductAddresses");
                });

            modelBuilder.Entity("RentVilla.Domain.Entities.Concrete.Region.State", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("CountryId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("States");
                });

            modelBuilder.Entity("RentVilla.Domain.Entities.Concrete.Region.UserAddress", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("AppUserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("CityId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("DistrictId")
                        .HasColumnType("TEXT");

                    b.Property<string>("StateId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId")
                        .IsUnique();

                    b.HasIndex("CityId");

                    b.HasIndex("DistrictId");

                    b.HasIndex("StateId");

                    b.ToTable("UserAddress");
                });

            modelBuilder.Entity("RentVilla.Domain.Entities.Concrete.Reservation", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("AdultNumber")
                        .HasColumnType("INTEGER");

                    b.Property<string>("AppUserId")
                        .HasColumnType("TEXT");

                    b.Property<int>("ChildrenNumber")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConversationId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Note")
                        .HasColumnType("TEXT");

                    b.Property<string>("PaymentId")
                        .HasColumnType("TEXT");

                    b.Property<string>("PaymentMethod")
                        .HasColumnType("TEXT");

                    b.Property<int>("PaymentType")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ProductId")
                        .HasColumnType("TEXT");

                    b.Property<double>("ProductPrice")
                        .HasColumnType("double");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<double>("TotalCost")
                        .HasColumnType("double");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.HasIndex("ProductId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("StateStateImageFile", b =>
                {
                    b.Property<string>("StateImageFilesId")
                        .HasColumnType("TEXT");

                    b.Property<string>("StatesId")
                        .HasColumnType("TEXT");

                    b.HasKey("StateImageFilesId", "StatesId");

                    b.HasIndex("StatesId");

                    b.ToTable("StateStateImageFile");
                });

            modelBuilder.Entity("RentVilla.Domain.Entities.Concrete.ProductImageFile", b =>
                {
                    b.HasBaseType("RentVilla.Domain.Entities.Concrete.File");

                    b.HasDiscriminator().HasValue("ProductImageFile");
                });

            modelBuilder.Entity("RentVilla.Domain.Entities.Concrete.Region.StateImageFile", b =>
                {
                    b.HasBaseType("RentVilla.Domain.Entities.Concrete.File");

                    b.HasDiscriminator().HasValue("StateImageFile");
                });

            modelBuilder.Entity("AppRoleEndpoint", b =>
                {
                    b.HasOne("RentVilla.Domain.Entities.Concrete.Endpoint", null)
                        .WithMany()
                        .HasForeignKey("EndpointsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RentVilla.Domain.Entities.Concrete.Identity.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RolesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("RentVilla.Domain.Entities.Concrete.Identity.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("RentVilla.Domain.Entities.Concrete.Identity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("RentVilla.Domain.Entities.Concrete.Identity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("RentVilla.Domain.Entities.Concrete.Identity.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RentVilla.Domain.Entities.Concrete.Identity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("RentVilla.Domain.Entities.Concrete.Identity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProductProductImageFile", b =>
                {
                    b.HasOne("RentVilla.Domain.Entities.Concrete.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RentVilla.Domain.Entities.Concrete.ProductImageFile", null)
                        .WithMany()
                        .HasForeignKey("ProductImageFilesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RentVilla.Domain.Entities.Concrete.Attribute.Attributes", b =>
                {
                    b.HasOne("RentVilla.Domain.Entities.Concrete.Attribute.AttributeType", "AttributeType")
                        .WithMany("Attributes")
                        .HasForeignKey("AttributeTypeId");

                    b.Navigation("AttributeType");
                });

            modelBuilder.Entity("RentVilla.Domain.Entities.Concrete.Attribute.ProductAttribute", b =>
                {
                    b.HasOne("RentVilla.Domain.Entities.Concrete.Attribute.AttributeType", "AttributeType")
                        .WithMany()
                        .HasForeignKey("AttributeTypeId");

                    b.HasOne("RentVilla.Domain.Entities.Concrete.Attribute.Attributes", "Attributes")
                        .WithMany()
                        .HasForeignKey("AttributesId");

                    b.HasOne("RentVilla.Domain.Entities.Concrete.Product", "Product")
                        .WithMany("Attributes")
                        .HasForeignKey("ProductId");

                    b.Navigation("AttributeType");

                    b.Navigation("Attributes");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("RentVilla.Domain.Entities.Concrete.Cart.ReservationCart", b =>
                {
                    b.HasOne("RentVilla.Domain.Entities.Concrete.Identity.AppUser", "User")
                        .WithMany("Carts")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("RentVilla.Domain.Entities.Concrete.Cart.ReservationCartItem", b =>
                {
                    b.HasOne("RentVilla.Domain.Entities.Concrete.Product", "Product")
                        .WithMany("CartItems")
                        .HasForeignKey("ProductId");

                    b.HasOne("RentVilla.Domain.Entities.Concrete.Cart.ReservationCart", "ReservationCart")
                        .WithMany("CartItems")
                        .HasForeignKey("ReservationCartId");

                    b.Navigation("Product");

                    b.Navigation("ReservationCart");
                });

            modelBuilder.Entity("RentVilla.Domain.Entities.Concrete.Endpoint", b =>
                {
                    b.HasOne("RentVilla.Domain.Entities.Concrete.Menu", "Menu")
                        .WithMany("Endpoints")
                        .HasForeignKey("MenuId");

                    b.Navigation("Menu");
                });

            modelBuilder.Entity("RentVilla.Domain.Entities.Concrete.Region.City", b =>
                {
                    b.HasOne("RentVilla.Domain.Entities.Concrete.Region.State", "State")
                        .WithMany()
                        .HasForeignKey("StateId");

                    b.Navigation("State");
                });

            modelBuilder.Entity("RentVilla.Domain.Entities.Concrete.Region.District", b =>
                {
                    b.HasOne("RentVilla.Domain.Entities.Concrete.Region.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId");

                    b.Navigation("City");
                });

            modelBuilder.Entity("RentVilla.Domain.Entities.Concrete.Region.ProductAddress", b =>
                {
                    b.HasOne("RentVilla.Domain.Entities.Concrete.Region.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId");

                    b.HasOne("RentVilla.Domain.Entities.Concrete.Region.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId");

                    b.HasOne("RentVilla.Domain.Entities.Concrete.Region.District", "District")
                        .WithMany()
                        .HasForeignKey("DistrictId");

                    b.HasOne("RentVilla.Domain.Entities.Concrete.Product", "Product")
                        .WithOne("ProductAddress")
                        .HasForeignKey("RentVilla.Domain.Entities.Concrete.Region.ProductAddress", "ProductId");

                    b.HasOne("RentVilla.Domain.Entities.Concrete.Region.State", "State")
                        .WithMany()
                        .HasForeignKey("StateId");

                    b.Navigation("City");

                    b.Navigation("Country");

                    b.Navigation("District");

                    b.Navigation("Product");

                    b.Navigation("State");
                });

            modelBuilder.Entity("RentVilla.Domain.Entities.Concrete.Region.State", b =>
                {
                    b.HasOne("RentVilla.Domain.Entities.Concrete.Region.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("RentVilla.Domain.Entities.Concrete.Region.UserAddress", b =>
                {
                    b.HasOne("RentVilla.Domain.Entities.Concrete.Identity.AppUser", "AppUser")
                        .WithOne("UserAddress")
                        .HasForeignKey("RentVilla.Domain.Entities.Concrete.Region.UserAddress", "AppUserId");

                    b.HasOne("RentVilla.Domain.Entities.Concrete.Region.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId");

                    b.HasOne("RentVilla.Domain.Entities.Concrete.Region.District", "District")
                        .WithMany()
                        .HasForeignKey("DistrictId");

                    b.HasOne("RentVilla.Domain.Entities.Concrete.Region.State", "State")
                        .WithMany()
                        .HasForeignKey("StateId");

                    b.Navigation("AppUser");

                    b.Navigation("City");

                    b.Navigation("District");

                    b.Navigation("State");
                });

            modelBuilder.Entity("RentVilla.Domain.Entities.Concrete.Reservation", b =>
                {
                    b.HasOne("RentVilla.Domain.Entities.Concrete.Identity.AppUser", "AppUser")
                        .WithMany("Reservations")
                        .HasForeignKey("AppUserId");

                    b.HasOne("RentVilla.Domain.Entities.Concrete.Product", "Product")
                        .WithMany("Reservations")
                        .HasForeignKey("ProductId");

                    b.Navigation("AppUser");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("StateStateImageFile", b =>
                {
                    b.HasOne("RentVilla.Domain.Entities.Concrete.Region.StateImageFile", null)
                        .WithMany()
                        .HasForeignKey("StateImageFilesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RentVilla.Domain.Entities.Concrete.Region.State", null)
                        .WithMany()
                        .HasForeignKey("StatesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RentVilla.Domain.Entities.Concrete.Attribute.AttributeType", b =>
                {
                    b.Navigation("Attributes");
                });

            modelBuilder.Entity("RentVilla.Domain.Entities.Concrete.Cart.ReservationCart", b =>
                {
                    b.Navigation("CartItems");
                });

            modelBuilder.Entity("RentVilla.Domain.Entities.Concrete.Identity.AppUser", b =>
                {
                    b.Navigation("Carts");

                    b.Navigation("Reservations");

                    b.Navigation("UserAddress");
                });

            modelBuilder.Entity("RentVilla.Domain.Entities.Concrete.Menu", b =>
                {
                    b.Navigation("Endpoints");
                });

            modelBuilder.Entity("RentVilla.Domain.Entities.Concrete.Product", b =>
                {
                    b.Navigation("Attributes");

                    b.Navigation("CartItems");

                    b.Navigation("ProductAddress");

                    b.Navigation("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}