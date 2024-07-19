using ShopEase.Application.Abstractions.Messaging;

namespace ShopEase.Application.Features.Products.Commands.CreateProduct;

public sealed record CreateProductCommand(string Name, string Description, int Quantity, decimal Price, Guid CategoryId) : ICommand;
