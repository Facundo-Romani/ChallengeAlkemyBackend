using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using BackendDisneyApi.DataAccess;
using BackendDisneyApi.Repositories;
using BackendDisneyApi.Services;
using BackendDisneyApi.Models;
using BackendDisneyApi.Services.Implements;

var builder = WebApplication.CreateBuilder(args);

// Connection DB SQL Server Express.
const string CONNECTIONNAME = "DisneyDB";
var connectionString = builder.Configuration.GetConnectionString(CONNECTIONNAME);

// Add Context.
builder.Services.AddDbContext<DisneyDBContext>(options => options.UseSqlServer(connectionString));


// Add services to the container. 
builder.Services.AddControllers();
//builder.Services.AddScoped<IMovieRepository, MovieOrSerieRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


