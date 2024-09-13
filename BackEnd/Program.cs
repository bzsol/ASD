using BackEnd.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = "";

if (!string.IsNullOrEmpty(builder.Configuration.GetConnectionString("PostgreSQL"))) {
    connectionString = builder.Configuration.GetConnectionString("PostgreSQL");
}
else {
    throw new InvalidOperationException("There's no connection string");
}


var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
var dbUser = Environment.GetEnvironmentVariable("DB_USER");
var dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD");
var dbSchema = Environment.GetEnvironmentVariable("DB_SCHEMA");


if (string.IsNullOrEmpty(dbHost) || string.IsNullOrEmpty(dbUser) || string.IsNullOrEmpty(dbPassword) || string.IsNullOrEmpty(dbSchema))
{
    
    var missingVariables = new List<string>();
    if (string.IsNullOrEmpty(dbHost)) missingVariables.Add("DB_HOST");
    if (string.IsNullOrEmpty(dbUser)) missingVariables.Add("DB_USER");
    if (string.IsNullOrEmpty(dbPassword)) missingVariables.Add("DB_PASSWORD");
    if (string.IsNullOrEmpty(dbSchema)) missingVariables.Add("DB_SCHEMA");

    
    throw new InvalidOperationException($"Missing environment variables: {string.Join(", ", missingVariables)}");
}


connectionString = connectionString
    .Replace("{DB_HOST}", dbHost)
    .Replace("{DB_USER}", dbUser)
    .Replace("{DB_PASSWORD}", dbPassword)
    .Replace("{DB_SCHEMA}", dbSchema);


builder.Services.AddEntityFrameworkNpgsql().AddDbContext<ApiDbContext>(opt => opt.UseNpgsql(builder.Configuration.GetConnectionString(connectionString)));

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
