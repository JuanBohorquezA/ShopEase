using ShopEase.Application.Abstractions.Messaging;

namespace ShopEase.Application.Features.Products.Commands.DeleteProduct;

public sealed record DeleteProductCommand(Guid productId) : ICommand;
