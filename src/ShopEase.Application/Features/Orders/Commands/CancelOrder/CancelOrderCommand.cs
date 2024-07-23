using ShopEase.Application.Abstractions.Messaging;

namespace ShopEase.Application.Features.Orders.Commands.CancelOrder;

public sealed record CancelOrderCommand(Guid OrderId) : ICommand;
