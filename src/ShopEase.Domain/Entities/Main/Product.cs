using ShopEase.Domain.Entities.Relations;

namespace ShopEase.Domain.Entities.Main;

public class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal Price { get; set; }

    public Guid CategoryId { get; set; }
    public Category Category { get; set; } = null!;
    public ICollection<OrderProduct> OrderProducts { get; set; } = null!;
}
