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
using SalesUp.MVC.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.LoadMyDbContextServices();

builder.Services.LoadMyIdentityServices();

builder.Services.LoadMyRepositoryServices();

builder.Services.LoadMyOtherServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

#region RouteRegions

app.MapAreaControllerRoute(
    name:"Customer",
    areaName:"Customer",
    pattern:"Customer/{controller=Home}/{action=Index}/{id?}"
);

app.MapAreaControllerRoute(
    name:"Admin",
    areaName:"Admin",
    pattern:"Admin/{controller=Home}/{action=Index}/{id?}"
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

#endregion

app.UpdateDatabase().Run();