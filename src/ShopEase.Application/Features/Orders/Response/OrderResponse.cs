
using ShopEase.Domain.Entities.Relations;

namespace ShopEase.Application.Features.Orders.Response;

public sealed record OrderResponse(Guid Id, DateTime OrderDate, string Status, ICollection<OrderProduct> OrderProducts);