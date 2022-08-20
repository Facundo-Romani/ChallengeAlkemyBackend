using Microsoft.EntityFrameworkCore;
using BackendDisneyApi.DataAccess;
using BackendDisneyApi.Repositories;
using BackendDisneyApi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using BackendDisneyApi.Models;
using BackendDisneyApi.Services.Implements;
using BackendDisneyApi.Base;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Connection DB SQL DisneyMovies
//const string CONNECTIONNAME = "DisneyDB"; 
var connectionString = builder.Configuration.GetConnectionString("DisneyDB");

// Connection DB SQL Users
var userString = builder.Configuration.GetConnectionString("UserConnection");

// Add Context
builder.Services.AddDbContext<DisneyDBContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddDbContext<UserDBContext>(options => options.UseSqlServer(userString));

// Add services to the container  
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Repository
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<ICharacterRepository, CharacterRepository>();

// Service
builder.Services.AddScoped<ICharacterService, CharacterService>();
builder.Services.AddScoped<IMovieService, MovieService>();

// Login Email
//builder.Services.AddScoped<IMailService, MailService>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline 
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();





