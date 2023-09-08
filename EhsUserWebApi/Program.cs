using EhsUserWebApi.Data;
using EhsUserWebApi.Models;
using EhsUserWebApi.Repository;
using EhsUserWebApi.Service;
using KissRepository;
using Microsoft.EntityFrameworkCore;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connection = String.Empty;
if (builder.Environment.IsDevelopment())
{
    builder.Configuration.AddEnvironmentVariables().AddJsonFile("appsettings.json");
    connection = builder.Configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING");
}
else
{
    connection = Environment.GetEnvironmentVariable("AZURE_SQL_CONNECTIONSTRING");
}

builder.Services.AddSingleton<IGenericRepository<User>>(x =>
{
    var repository = new UserRepository(connection);
    return repository;
});

builder.Services.AddSingleton<UserService>();

builder.Services.AddDbContext<UserMgmtContext>(options =>
            options.UseSqlServer(connection));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    
    app.UseItToSeedSqlServer();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
