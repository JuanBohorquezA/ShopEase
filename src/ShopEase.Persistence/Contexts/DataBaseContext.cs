using Microsoft.EntityFrameworkCore;
using ShopEase.Domain.Entities.Main;
using ShopEase.Domain.Entities.Relations;
using ShopEase.Persistence.ModelBuildersConfig.Main;
using ShopEase.Persistence.ModelBuildersConfig.Relations;

namespace ShopEase.Persistence.Contexts;

public class DataBaseContext : DbContext
{
    public DbSet<Category> Categorys { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderProduct> OrderProducts { get; set; }

    public DataBaseContext(DbContextOptions options) : base(options) { }
    public DataBaseContext() { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer("Server=DESKTOP-MGG7DTP;Database=ShopEase;User Id=TestUser;Password=1234;TrustServerCertificate=true;");
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new CategoryConfig());
        builder.ApplyConfiguration(new OrderConfig());
        builder.ApplyConfiguration(new ProductConfig());
        builder.ApplyConfiguration(new OrderProductConfig());
    }
}
