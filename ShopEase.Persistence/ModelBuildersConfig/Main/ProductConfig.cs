using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopEase.Domain.Entities.Main;

namespace ShopEase.Persistence.ModelBuildersConfig.Main;

internal class ProductConfig : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable(nameof(Product));

        builder.HasKey(p => p.Id);

        builder
            .Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder
            .Property(p => p.Description)
            .HasMaxLength(500);

        builder
            .Property(p => p.Quantity)
            .IsRequired();

        builder
            .Property(p => p.Price)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder
            .HasOne(p => p.Category)
            .WithMany(C => C.Products)
            .HasForeignKey(p => p.CategoryId);

        builder
            .HasMany(p => p.OrderProducts)
            .WithOne(op => op.Product)
            .HasForeignKey(p => p.ProductId);

    }
}
