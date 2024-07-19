using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using ShopEase.Application.Common;

namespace ShopEase.Presentation.Abstractions;

public static class CorsConfiguration
{
    public static IServiceCollection AddCorsDocumentation(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy(AppConfig.CorsName, builder =>
            {
                builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
            });
        });
        return services;
    }
    public static IApplicationBuilder UseCorsDocumentation(this IApplicationBuilder application)
    {
        application.UseCors(AppConfig.CorsName);
        return application;
    }
}
