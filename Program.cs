using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Load environment variables from .env file if not already loaded
DotNetEnv.Env.Load();

// Get the connection string from the environment variable
var connectionString = Environment.GetEnvironmentVariable("DbInfo");
if (string.IsNullOrEmpty(connectionString))
{
    throw new ArgumentException("Database connection string is missing in environment variables.");
}

// Add services to the container.
builder.Services.AddDbContext<BankingContext>(options =>
    options.UseMySql(connectionString,
                     new MySqlServerVersion(new Version(8, 0, 33))));

// Add Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Banking API", Version = "v1" });
});

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    // Enable middleware to serve generated Swagger as a JSON endpoint.
    app.UseSwagger();
    // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
    // specifying the Swagger JSON endpoint.
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Banking API V1"));
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
