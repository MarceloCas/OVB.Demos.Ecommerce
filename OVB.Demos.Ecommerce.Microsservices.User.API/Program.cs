using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using OVB.Demos.Ecommerce.Microsservices.User.Domain.Contracts.Repositories;
using OVB.Demos.Ecommerce.Microsservices.User.Domain.Contracts.Services.Adapters;
using OVB.Demos.Ecommerce.Microsservices.User.Domain.Contracts.Services.Cryptography;
using OVB.Demos.Ecommerce.Microsservices.User.Domain.Contracts.Services.Logging;
using OVB.Demos.Ecommerce.Microsservices.User.Domain.Contracts.Services.Messenger;
using OVB.Demos.Ecommerce.Microsservices.User.Domain.Contracts.Services.Token;
using OVB.Demos.Ecommerce.Microsservices.User.Domain.Models.DTOs.User;
using OVB.Demos.Ecommerce.Microsservices.User.Domain.Models.Entities;
using OVB.Demos.Ecommerce.Microsservices.User.Domain.Models.Validators;
using OVB.Demos.Ecommerce.Microsservices.User.Infrascructure.Data;
using OVB.Demos.Ecommerce.Microsservices.User.Infrascructure.Data.Repositories;
using OVB.Demos.Ecommerce.Microsservices.User.Services.Adapters;
using OVB.Demos.Ecommerce.Microsservices.User.Services.Cryptography;
using OVB.Demos.Ecommerce.Microsservices.User.Services.Logging;
using OVB.Demos.Ecommerce.Microsservices.User.Services.Messenger;
using OVB.Demos.Ecommerce.Microsservices.User.Services.Token;

namespace OVB.Demos.Ecommerce.Microsservices.User.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
    
        builder.Services.AddControllers();

        builder.Services.AddApiVersioning(options =>
        {
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.DefaultApiVersion = new ApiVersion(majorVersion: 1, minorVersion: 0);
            options.ReportApiVersions = true;
        });

        builder.Services.AddMemoryCache();

        builder.Services.AddDbContext<DataContext>(p => p.UseSqlite("Data Source=microsservice.db", b => b.MigrationsAssembly("OVB.Demos.Ecommerce.Microsservices.User.Infrascructure.Data")));

        builder.Services.AddTransient<IValidator<UserBase>, CreateUserValidator>();
        builder.Services.AddTransient<ICryptographyService, CryptographyService>();
        builder.Services.AddTransient<IMessengerService, MessengerService>();
        builder.Services.AddTransient<ITokenService, TokenService>();
        builder.Services.AddTransient<IAdapter<UserBase, UserEntity>, AdapterUserEntityToUser>();
        builder.Services.AddTransient<IAdapter<UserEntity, UserBase>, AdapterUserToUserEntity>();

        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<IBaseRepository<UserEntity>, UserRepository>();
        builder.Services.AddScoped<ILoggingService, LoggingService>();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "Ecommerce",
                Description = "Desenvolvimento de um mercado online de atacado e varejo de produtos",
                Contact = new OpenApiContact()
                {
                    Name = "Otávio Villas Boas Simoncini Carmanini",
                    Email = "otaviovb.developer@gmail.com",
                    Url = new Uri("https://github.com/otaviovb")
                }
            });
        });

        var app = builder.Build();
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}