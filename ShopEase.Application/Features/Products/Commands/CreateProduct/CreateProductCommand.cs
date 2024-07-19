using ShopEase.Application.Abstractions.Messaging;

namespace ShopEase.Application.Features.Products.Commands.CreateProduct;

public sealed record CreateProductCommand(string name, string Description, int quantity, decimal price, Guid CategoryId) : ICommand;
