using ShopEase.Application.Abstractions.Messaging;

namespace ShopEase.Application.Features.Orders.Commands.MakeOrder;

public sealed record MakeOrderCommand(DateTime DateOrder, Dictionary<Guid, int> products) : ICommand;
