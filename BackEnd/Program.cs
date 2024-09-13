using BackEnd.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Retrieve the connection string with placeholders
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Retrieve environment variables or configuration values
var dbHost = Environment.GetEnvironmentVariable("DB_HOST") ?? "localhost";
var dbUser = Environment.GetEnvironmentVariable("DB_USER") ?? "postgres";
var dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD") ?? "password";
var dbSchema = Environment.GetEnvironmentVariable("DB_SCHEMA") ?? "postgres";

// Replace placeholders with actual values
connectionString = connectionString
    .Replace("{DB_HOST}", dbHost)
    .Replace("{DB_USER}", dbUser)
    .Replace("{DB_PASSWORD}", dbPassword)
    .Replace("{DB_SCHEMA}", dbSchema);

// Use the connection string to configure DbContext
builder.Services.AddDbContext<ApiDbContext>(options =>
    options.UseNpgsql(connectionString));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());


app.UseAuthorization();

app.MapControllers();

app.Run();
