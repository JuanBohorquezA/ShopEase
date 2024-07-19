using Microsoft.Extensions.Configuration;

namespace ShopEase.Application.Common;

public static class AppConfig
{
    private static readonly IConfiguration Configuration;
    static AppConfig()
    {
        Configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();
    }

    public static string ConnectionDB => Configuration["ConnectionStrings:DBConections"]!;
    public static string CorsName => Configuration["Cors:CorsName"]!;
}
