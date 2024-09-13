using BackEnd.Data;
using Microsoft.EntityFrameworkCore;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var dbHost = Environment.GetEnvironmentVariable("DB_HOST") ?? throw new InvalidOperationException("DB_HOST is not set");
var dbUser = Environment.GetEnvironmentVariable("DB_USER") ?? throw new InvalidOperationException("DB_USER is not set");
var dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD") ?? throw new InvalidOperationException("DB_PASSWORD is not set");
var dbSchema = Environment.GetEnvironmentVariable("DB_SCHEMA") ?? throw new InvalidOperationException("DB_SCHEMA is not set");

var connectionString = ""
    .Replace("{DB_HOST}", dbHost)
    .Replace("{DB_USER}", dbUser)
    .Replace("{DB_PASSWORD}", dbPassword)
    .Replace("{DB_SCHEMA}", dbSchema);

Console.WriteLine(connectionString);

Console.WriteLine($"DB_PASSWORD: {dbPassword}");


var connString = "Host=postgres-srv;Port=5432;Database=postgres;Username=postgres;Password=password;";
using (var connection = new NpgsqlConnection(connString))
{
    try
    {
        connection.Open();
        Console.WriteLine("Connection to the database succeeded!");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error connecting to the database: {ex.Message}");
    }
}



builder.Services.AddDbContext<ApiDbContext>(opt =>
    opt.UseNpgsql(builder.Configuration.GetConnectionString(builder.Configuration.GetConnectionString("DefaultConnection"))));


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
