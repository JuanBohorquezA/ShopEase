using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace ShopEase.Presentation.Abstractions;

public static class SwaggerConfiguration
{
    public static void AddSwaggerConfig(this IServiceCollection services)
    {
        services.AddSwaggerGen(opt =>
        {
            opt.SwaggerDoc("v1", new OpenApiInfo { Title = "Rentamed API", Version = "v1" });
            opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Please enter token",
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                BearerFormat = "JWT",
                Scheme = "bearer",
            });

            opt.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
            {
                Description = "ApiKey must appear in header",
                Type = SecuritySchemeType.ApiKey,
                Name = "ApiKey",
                In = ParameterLocation.Header,
                Scheme = "ApiKeyScheme"
            });


            opt.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        },
                    },
                    new string[] { }
                }
            });

            opt.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "ApiKey"
                        },
                        In = ParameterLocation.Header
                    },
                    new string[] { }
                }
            });
        });
    }
}
