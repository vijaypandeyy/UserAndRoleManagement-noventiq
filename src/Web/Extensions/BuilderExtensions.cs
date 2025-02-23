using Application;
using Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Runtime.CompilerServices;

namespace Web.Extensions
{
    public static class BuilderExtensions
    {

        public static IServiceCollection AddApplicationLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddApplicationServices(configuration);
            return services;
        }

        public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
        {
           services.AddInfrastructureServices(configuration);
            return services;
        }

        public static IServiceCollection AddWebLayer(this WebApplicationBuilder builder, IConfiguration configuration)
        {
            //AddTokenValidation(builder, configuration);
            //AddSwaggerSettings(builder);
            return builder.Services;
        }
        public static void AddTokenValidation(this WebApplicationBuilder builder, IConfiguration configuration)
        {
            builder.Services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.Authority = configuration["Auh0:Issuer"];
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = false,
                        ValidateIssuer = true,
                        ValidIssuer = configuration["Auh0:Issuer"],
                        ValidateAudience = true,
                        ValidAudience = configuration["Auh0:Audience"],
                        ValidateLifetime = false,
                    };
                });
        }

        public static void AddSwaggerSettings( this WebApplicationBuilder builder)
        {
            builder.Services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter 'Bearer' [space] and then your token in the text input below.\nExample: 'Bearer abcdef123456'",
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
            });
        }
    }
}
