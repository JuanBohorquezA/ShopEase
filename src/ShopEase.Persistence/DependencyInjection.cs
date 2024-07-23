using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShopEase.Application.Common;
using ShopEase.Domain.Abstractions;
using ShopEase.Persistence.Contexts;

namespace ShopEase.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddDbContext<DataBaseContext>(options =>
                options.UseSqlServer(AppConfig.ConnectionDB));

        services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork.UnitOfWork));

        return services;
    }
}
