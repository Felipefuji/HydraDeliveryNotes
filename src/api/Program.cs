using api.Assets;
using data.Data.APIContext.Context;
using data.Data.APIContext.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var connString = builder.Configuration.GetConnectionString("LocalDB");
var jwtConfiguration = builder.Configuration.GetSection("Jwt");

// Add services to the container.

builder.Services.AddDbContext<APIContext>(options => options.UseSqlServer(connString).EnableSensitiveDataLogging(true));

//Authentication
builder.Services.AddIdentity<User, Role>(options =>
{
    options.Password.RequiredLength = 8;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1d);
    options.Lockout.MaxFailedAccessAttempts = 5;
}).AddEntityFrameworkStores<APIContext>().AddDefaultTokenProviders();

builder.Services.Configure<JwtSettings>(jwtConfiguration);
var jwtSettings = jwtConfiguration.Get<JwtSettings>();

builder.Services.AddAuthorization()
    .AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidIssuer = jwtSettings.Issuer,
            ValidAudience = jwtSettings.Issuer,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret)),
            ClockSkew = TimeSpan.Zero
        };
    });

//Policity
builder.Services.AddCors();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "API",
        Description = "HydraDeliveryNotes API",
        TermsOfService = new Uri("https://hydratech.es/")
    });
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Please enter a valid token",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
    });
    var security = new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                },
                UnresolvedReference = true
            },
            new string[]{}
        }
    };
    options.AddSecurityRequirement(security);
});

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

//Controllers
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
