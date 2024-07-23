using ShopEase.Domain.Entities.Main;

namespace ShopEase.Domain.Entities.Relations;

public class OrderProduct
{
    public Guid OrderId { get; set; }
    public Order Order { get; set; } = null!;

    public Guid ProductId { get; set; }
    public Product Product { get; set; } = null!;
}
