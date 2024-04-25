using DiziSinema.Business.Absract;
using DiziSinema.Business.Concrete;
using DiziSinema.Data.Abstract;
using DiziSinema.Data.Concrete.Context;
using DiziSinema.Data.Concrete.Repositories;
using Microsoft.EntityFrameworkCore;
using DiziSinema.Shared.Helpers.Abstract;
using DiziSinema.Shared.Helpers.Concrete;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();


builder.Services.AddDbContext<DiziSinemaDbContext>(option => option.UseSqlite(builder.Configuration.GetConnectionString("SqliteConnectiom")));



builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IGenreRepository, GenreRepoitory>();
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<ISerialTvRepository, SerialTvRepository>();

builder.Services.AddScoped<IGenreService, GenreManager>();
builder.Services.AddScoped<IMovieService, MovieManager>();
builder.Services.AddScoped<ISerialTvSevice, SerialTvManager>();

builder.Services.AddScoped<IImageHelper, ImageHelper>();



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
