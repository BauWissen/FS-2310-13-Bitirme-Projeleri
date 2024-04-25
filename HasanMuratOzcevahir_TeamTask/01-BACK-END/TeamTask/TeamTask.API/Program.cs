using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TeamTask.Business.Abstract;
using TeamTask.Business.Concrete;
using TeamTask.Business.Mapping;
using TeamTask.Data.Abstract;
using TeamTask.Data.Concrete;
using TeamTask.BuilderServices;
using TeamTask.Data.Contexts;
using TeamTask.Entity.Concrete.Identity;
using TeamTask.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

IServiceCollection s = builder.Services;


 s.UseAllServices();


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

app.SetCorsPolicy();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();



app.MapControllers();

app.Run();
