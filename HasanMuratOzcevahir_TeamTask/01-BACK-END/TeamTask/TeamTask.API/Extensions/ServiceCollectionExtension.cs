using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TeamTask.Business.Abstract;
using TeamTask.Business.Concrete;
using TeamTask.Business.Mapping;
using TeamTask.Data.Abstract;
using TeamTask.Data.Concrete;
using TeamTask.Data.Contexts;
using TeamTask.Entity.Concrete.Identity;

namespace TeamTask.BuilderServices
{
    public static class ServiceCollectionExtension
    {
        public static void UseAllServices(this IServiceCollection service)
        {
            GenerateRepositoryService(service);
            GenerateManagerService(service);
            GenerateIdentityService(service);
            ConfigureIdentityService(service);
            ConfigureCookieService(service);
            GenerateAutoMapperService(service);
            GenerateDBContextService(service);
        }
        private static IServiceCollection GenerateRepositoryService(IServiceCollection services)
        {
            services.AddScoped<IWorkingSpaceRepository, WorkingSpaceRepository>();
            services.AddScoped<IStatusRepository, StatusRepository>();
            services.AddScoped<ITaskRepository, TaskRepository>();
            services.AddScoped<ITaskStatusRepository, TaskStatusRepository>();
            services.AddScoped<IUserNoteRepository, UserNoteRepository>();

            return services;
        }
        private static IServiceCollection GenerateManagerService(IServiceCollection services)
        {
            services.AddScoped<IWorkingSpaceService, WorkingSpaceManager>();
            services.AddScoped<IStatusService, StatusManager>();
            services.AddScoped<ITaskService, TaskManager>();
            services.AddScoped<ITaskStatusService, TaskStatusManager>();
            services.AddScoped<IUserNoteService, UserNoteManager>();

            return services;
        }
        private static IServiceCollection GenerateIdentityService(IServiceCollection services)
        {
            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<TeamTaskDBContext>()
                .AddDefaultTokenProviders();
            return services;
        }
        private static IServiceCollection ConfigureIdentityService(IServiceCollection services)
        {
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireLowercase = false;
                options.Password.RequiredUniqueChars = 0;

            });

            return services;
        }
        private static IServiceCollection ConfigureCookieService(IServiceCollection services)
        {
            services.ConfigureApplicationCookie(options =>
             {

                 options.ExpireTimeSpan = TimeSpan.FromDays(10);
                 options.SlidingExpiration = true;
                 options.Cookie = new CookieBuilder
                 {
                     Name = "TeamTask.Cookie",
                     HttpOnly = true,
                     SameSite = SameSiteMode.Strict
                 };
             });
            return services;
        }
        private static IServiceCollection GenerateAutoMapperService(IServiceCollection services)
        {
            services.AddAutoMapper(
            config =>
            {
                config.AddProfile<MappingProfileGeneral>();
                config.AddProfile<MappingProfileUser>();
                config.AddProfile<MappingProfileWorkingSpace>();
                config.AddProfile<MappingProfileTask>();
                config.AddProfile<MappingProfileWorkingSpaceComment>();
            });

            return services;

        }
        private static IServiceCollection GenerateDBContextService(IServiceCollection services)
        {
            services.AddDbContext<TeamTaskDBContext>(options =>
                     options.UseSqlite(services
                        .BuildServiceProvider()
                        .GetRequiredService<IConfiguration>()
                        .GetConnectionString("SqliteConnection"))
                        );

            return services;
        }

    }
}
