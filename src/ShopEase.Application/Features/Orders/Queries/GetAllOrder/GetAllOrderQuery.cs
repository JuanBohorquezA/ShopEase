using ShopEase.Application.Abstractions.Messaging;
using ShopEase.Application.Features.Orders.Response;

namespace ShopEase.Application.Features.Orders.Queries.GetAllOrder;

public sealed record GetAllOrderQuery() : IQuery<IEnumerable<OrderResponse>>;
