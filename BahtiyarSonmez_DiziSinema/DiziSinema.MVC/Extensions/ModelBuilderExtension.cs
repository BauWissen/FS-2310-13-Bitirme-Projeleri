using DiziSinema.MVC.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DiziSinema.MVC.Extensions
{
    public static class ModelBuilderExtension
    {
        public static void SeedData(this ModelBuilder modelBuilder) 
        {
            #region Rol bilgileri
            List<Role> roles = new List<Role>
            {
               new Role{Name="SuperAdmin", Description="Süper Yönetici haklarını taşıyan rol", NormalizedName="SUPERADMIN"},
                new Role{Name="Admin", Description="Yönetici haklarını taşıyan rol", NormalizedName="ADMIN"},
            };
            modelBuilder.Entity<Role>().HasData(roles);
            #endregion

            #region Kullanıcı İşlemleri
            List<User> users = new List<User>
            {
                new User
                {
                    FirstName="Talut",
                    LastName="Sönmez",
                    UserName="talutsonmez",
                    NormalizedUserName="TALUTSONMEZ",
                    Email="talutsonmez@gmail.com",
                    NormalizedEmail="TALUTSONMEZ@GMAIL.COM",
                    Gender="Erkek",
                    DateOfBirth=new DateTime(2018,5,12),
                    Address="Kocaeli/Karamürsel/Kırık Merdiven",
                    City="Kocaeli",
                    PhoneNumber="5558779955",
                    EmailConfirmed=true
                },
                new User
                {
                    FirstName="Bahtiyar",
                    LastName="Sönmez",
                    UserName="bahtiyarsonmez",
                    NormalizedUserName="BAHTIYARSONMEZ",
                    Email="bahtiyarsonmez@gmail.com",
                    NormalizedEmail="BAHTIYARSONMEZ@GMAIL.COM",
                    Gender="Erkek",
                    DateOfBirth=new DateTime(1990,5,12),
                    Address="Kocaeli/Karamürsel/Kırık Merdiven",
                    City="Kocaeli",
                    PhoneNumber="5558779966",
                    EmailConfirmed=true
                },
                new User
                {
                    FirstName="Emrullah",
                    LastName="Karaca",
                    UserName="emrullahkaraca",
                    NormalizedUserName="EMRULLAHKARACA",
                    Email="emrullahkaraca@gmail.com",
                    NormalizedEmail="EMRULLAHKARACA@GMAIL.COM",
                    Gender="Erkek",
                    DateOfBirth=new DateTime(1990,5,12),
                    Address="Kocaeli/Karamürsel/Kırık Merdiven",
                    City="Kocaeli",
                    PhoneNumber="5558779911",
                    EmailConfirmed=true
                },
                                new User
                {
                    FirstName="Numan",
                    LastName="Demirhan",
                    UserName="numandemirhan",
                    NormalizedUserName="NUMANDEMIRHAN",
                    Email="numandemirhan@gmail.com",
                    NormalizedEmail="NUMANDEMIRHAN@GMAIL.COM",
                    Gender="Erkek",
                    DateOfBirth=new DateTime(1990,5,12),
                    Address="Kocaeli/Karamürsel/Kırık Merdiven",
                    City="Kocaeli",
                    PhoneNumber="5558779911",
                    EmailConfirmed=true
                }
            };
            modelBuilder.Entity<User>().HasData(users);
            #endregion

            #region Şifre İşlemleri
            var passwordHasher = new PasswordHasher<User>();
            users[0].PasswordHash = passwordHasher.HashPassword(users[0], "Qwe123.");
            users[1].PasswordHash = passwordHasher.HashPassword(users[1], "Qwe123.");
            users[2].PasswordHash = passwordHasher.HashPassword(users[2], "Qwe123.");
            users[3].PasswordHash = passwordHasher.HashPassword(users[3], "Qwe123.");
            #endregion

            #region Rol Atama
            List<IdentityUserRole<string>> userRoles = new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string>
                {
                    UserId=users[0].Id,
                    RoleId=roles[0].Id,
                },
                new IdentityUserRole<string>
                {
                    UserId=users[1].Id,
                    RoleId=roles[0].Id,
                },
                new IdentityUserRole<string>
                {
                    UserId=users[2].Id,
                    RoleId=roles[1].Id,
                },
                new IdentityUserRole<string>
                {
                    UserId=users[3].Id,
                    RoleId=roles[1].Id,
                }
            };
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(userRoles);
            #endregion
        }
    }
}
