using Autofac;
using Autofac.Extensions.DependencyInjection;
using MansionRentBackend.Application;
using MansionRentBackend.Application.DbContexts;
using MansionRentBackend.API;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.Events;
using System.Reflection;
using System.Text;
using MansionRentBackend.Application.Entities;
using Microsoft.AspNetCore.Identity;
using MansionRentBackend.Application.Services.Auth;
using MansionRentBackend.Application.Securities;
using Microsoft.AspNetCore.Authorization;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((ctx, lc) => lc
    .MinimumLevel.Debug()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
    .Enrich.FromLogContext()
    .ReadFrom.Configuration(builder.Configuration));

try
{
    // Add services to the container.
    var connectionString = builder.Configuration.GetConnectionString("MansionDbConnection");
    var assemblyName = Assembly.GetExecutingAssembly().FullName;
    var key = builder.Configuration.GetValue<string>("ApiSettings:Secret");

    builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
    builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
    {
        containerBuilder.RegisterModule(new ApiModule());
        containerBuilder.RegisterModule(new InfrastructureModule(connectionString,
            assemblyName));
    });

    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(connectionString, 
        m => m.MigrationsAssembly(assemblyName)));

    builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

    builder.Services
        .AddIdentity<ApplicationUser, ApplicationRole>()
        .AddEntityFrameworkStores<ApplicationDbContext>()
        .AddUserManager<ApplicationUserManager>()
        .AddRoleManager<ApplicationRoleManager>()
        .AddSignInManager<ApplicationSignInManager>()
        .AddDefaultTokenProviders();

    builder.Services.AddAuthentication(x =>
    {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, x =>
    {
        x.RequireHttpsMetadata = false;
        x.SaveToken = true;
        x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["Jwt:Key"])),
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
        };
    });

    builder.Services.Configure<IdentityOptions>(options =>
    {
        // Password settings.
        options.Password.RequireDigit = false;
        options.Password.RequireLowercase = false;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireUppercase = false;
        options.Password.RequiredLength = 4;
        options.Password.RequiredUniqueChars = 0;
    });

    builder.Services.AddAuthorization(options =>
    {
        options.AddPolicy("ApiProjectListRequirementPolicy", policy =>
        {
            policy.AuthenticationSchemes.Clear();
            policy.AuthenticationSchemes.Add(JwtBearerDefaults.AuthenticationScheme);
            policy.RequireAuthenticatedUser();
            policy.Requirements.Add(new ApiProjectListRequirement());
        });
    });

    builder.Services.AddSingleton<IAuthorizationHandler, ApiProjectListRequirementHandler>();

    builder.Services.AddControllers();

    builder.Services.AddEndpointsApiExplorer();

    builder.Services.AddSwaggerGen();

    var app = builder.Build();

    Log.Information("Web API is starting");

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
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application start-up failed");
}
finally
{
    Log.CloseAndFlush();
}