using Microsoft.Extensions.DependencyInjection;
using ShopEase.Presentation.Abstractions;

namespace ShopEase.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddSwaggerConfig();
        services.AddCorsDocumentation();

        return services;
    }
}
