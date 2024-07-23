using ShopEase.Application.Abstractions.Messaging;
using ShopEase.Application.Features.Products.Response;

namespace ShopEase.Application.Features.Products.Commands.UpdateProduct;

public sealed record  UpdateProductCommand(Guid productId, int Quantity, decimal Price) : ICommand<Guid>;
