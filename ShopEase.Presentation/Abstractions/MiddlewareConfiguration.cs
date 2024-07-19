using Microsoft.AspNetCore.Builder;
using ShopEase.Presentation.Middlewares;

namespace ShopEase.Presentation.Abstractions;

public static class MiddlewareConfiguration
{
    public static IApplicationBuilder AddMiddlewares(this IApplicationBuilder application)
    {
        application.UseMiddleware<ExceptionHandlingMiddleware>();

        return application;
    }
}
