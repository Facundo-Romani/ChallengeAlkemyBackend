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
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

// Configure Swagger Authorization
// builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Pre-Aceleracion-API.Disney", Version = "v1" });
    option.AddSecurityDefinition("Bearer",
    new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Ingrese Bearer [Token] para poder identificarse dentro de la aplicación",
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new List<string>()
        }
    });
});

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

// DI to implement the Login system
builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<UserDBContext>()
    .AddDefaultTokenProviders();

// DI to Configure token and Authentication
builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(option =>
{
    option.SaveToken = true;
    option.RequireHttpsMetadata = false; // required in production environment //option.Authority = "https://localhost:7030";
    
    option.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = "https://localhost:7030", // my port
        ValidIssuer = "https://localhost:7030",
        IssuerSigningKey =
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes("JWTRefreshTokenHIGHsecuredPasswordVVVp1OH7Xzyr"))
    };
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle



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





