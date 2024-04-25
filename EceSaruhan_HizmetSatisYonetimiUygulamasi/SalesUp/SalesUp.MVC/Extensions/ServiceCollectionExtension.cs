using AspNetCoreHero.ToastNotification;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SalesUp.Business.Abstract;
using SalesUp.Business.Concrete;
using SalesUp.Business.Mappings;
using SalesUp.Data.Abstract;
using SalesUp.Data.Concrete.Contexts;
using SalesUp.Data.Concrete.Repositories;
using SalesUp.Entity.Identity;
using SalesUp.MVC.EmailServices.Abstract;
using SalesUp.MVC.EmailServices.Concrete;

namespace SalesUp.MVC.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection LoadMyDbContextServices(this IServiceCollection services)
    {
        services.AddDbContext<SalesUpDbContext>(options =>
            options
                .UseSqlite(services
                    .BuildServiceProvider()
                    .GetRequiredService<IConfiguration>()
                    .GetConnectionString("SqliteConnection")));
        return services;
    }

    public static IServiceCollection LoadMyIdentityServices(this IServiceCollection services)
    {
        services.AddIdentity<User, Role>()
            .AddEntityFrameworkStores<SalesUpDbContext>()
            .AddDefaultTokenProviders();

        services.Configure<IdentityOptions>(options =>
        {
            #region Parola Ayarları

            options.Password.RequiredLength = 6;
            options.Password.RequireDigit = true;
            options.Password.RequireNonAlphanumeric = true;
            options.Password.RequireUppercase = true;
            options.Password.RequireLowercase = true;

            #endregion

            #region Hesap Kilitleme Ayarları

            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromSeconds(50);
            options.Lockout.MaxFailedAccessAttempts = 3;

            #endregion

            options.User.RequireUniqueEmail = true;
            options.SignIn.RequireConfirmedEmail = false;
        });

        services.ConfigureApplicationCookie(options =>
        {
            options.LoginPath = "/Account/Login";
            options.LogoutPath = "/";
            options.AccessDeniedPath = "/Account/AccessDenied";
            options.ExpireTimeSpan = TimeSpan.FromDays(10);
            options.SlidingExpiration = true;
            options.Cookie = new CookieBuilder
            {
                Name = "SalesUp.Security.Cookie",
                HttpOnly = true,
                SameSite = SameSiteMode.Strict
            };
        });
        return services;
    }

    public static IServiceCollection LoadMyRepositoryServices(this IServiceCollection services)
    {
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IMessageRepository, MessageRepository>();
        services.AddScoped<ISTaskRepository, STaskRepository>();
        services.AddScoped<ISaleRepository, SaleRepository>();
        services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IContactUsRepository, ContactUsRepository>();

        services.AddScoped<IProductService, ProductManager>();
        services.AddScoped<ICustomerService, CustomerManager>();
        services.AddScoped<IMessageService, MessageManager>();
        services.AddScoped<ISTaskService, STaskManager>();
        services.AddScoped<ISaleService, SaleManager>();
        services.AddScoped<ISubscriptionService, SubscriptionManager>();
        services.AddScoped<IOrderService, OrderManager>();
        services.AddScoped<IContactUsService, ContactUsManager>();

        return services;
    }

    public static IServiceCollection LoadMyOtherServices(this IServiceCollection services)
    {
        // services.AddScoped<MapperlyConfig>();
        
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        
        services.AddScoped<IEmailSender, EmailSender>(options=>new EmailSender(
            services.BuildServiceProvider().GetRequiredService<IConfiguration>()["EmailSender:Host"],

            services.BuildServiceProvider().GetRequiredService<IConfiguration>().GetValue<int>("EmailSender:Port"),
            services.BuildServiceProvider().GetRequiredService<IConfiguration>().GetValue<bool>("EmailSender:EnableSSL"),
            services.BuildServiceProvider().GetRequiredService<IConfiguration>()["EmailSender:UserName"],
            services.BuildServiceProvider().GetRequiredService<IConfiguration>()["EmailSender:Password"]
        ));
        services.AddNotyf(options =>
        {
            options.DurationInSeconds = 3;
            options.IsDismissable = true;
            options.Position = NotyfPosition.TopRight;
        });
        return services;
    }
}