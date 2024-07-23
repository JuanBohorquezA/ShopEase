using ShopEase.Domain.Entities.Relations;

namespace ShopEase.Domain.Entities.Main;

public class Order
{
    public Guid Id { get; set; }
    public DateTime OrderDate { get; set; }
    public ICollection<OrderProduct> OrderProducts { get; set; } = null!;
}
