using api.Assets;
using data.Data.APIContext.Context;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
var connString = builder.Configuration.GetConnectionString("LocalDB");

// Add services to the container.

builder.Services.AddDbContext<APIContext>(options => options.UseSqlServer(connString).EnableSensitiveDataLogging(true));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Scrutor Dependency Injection
builder.Services.Scan(scan => scan
                .FromAssemblies(Assembly.Load("core"), Assembly.Load("data"))
                .AddClasses(c => c.Where(d =>
                    d.Name.EndsWith("Service")
                    || d.Name.EndsWith("Repository")
                    || d.Name.EndsWith("Factory")
                    || d.Name.EndsWith("Access")))
                .AsImplementedInterfaces()
                .WithScopedLifetime());
//AutoMapper
builder.Services.AddAutoMapper(typeof(AutoMapping));

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
