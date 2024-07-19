using ShopEase.Application.Abstractions.Messaging;

namespace ShopEase.Application.Features.Products.Commands.UpdateProduct;

public sealed record  UpdateProductCommand(Guid productId, int Quantity, decimal Price) : ICommand;
