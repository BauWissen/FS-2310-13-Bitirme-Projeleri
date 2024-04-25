using DiziSinema.MVC.Dal;
using DiziSinema.MVC.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();



builder.Services.AddDbContext<Db>(options => options.UseSqlite(builder.Configuration.GetConnectionString("SqliteConnectiom")));


builder.Services.AddIdentity<User, Role>()
    .AddEntityFrameworkStores<Db>();

builder.Services.Configure<IdentityOptions>(options =>
{
    #region Parola Ayarlarý
    options.Password.RequiredLength = 6;
    options.Password.RequireDigit = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireLowercase = true;
    #endregion

    #region Hesap Kilitleme Ayarlarý
    options.Lockout.MaxFailedAccessAttempts = 3;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromSeconds(15);
    #endregion

    options.User.RequireUniqueEmail = true;
    options.SignIn.RequireConfirmedEmail = false;
});

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";
    options.LogoutPath = "/";
    options.AccessDeniedPath = "/Account/AccessDenied";
    options.ExpireTimeSpan = TimeSpan.FromDays(45);
    options.SlidingExpiration = true;
    options.Cookie = new CookieBuilder
    {
        Name = "DiziSinema.Security.Cookie",
        HttpOnly = true,
        SameSite = SameSiteMode.Strict
    };
});





var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapAreaControllerRoute(
    name: "Admin",
    areaName: "Admin",
    pattern: "Admin/{controller=Home}/{action=Index}/{id?}"
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
