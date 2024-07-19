namespace ShopEase.Application.Features.Products.Response;

public sealed record ProductResponse(Guid ProductId, string Name, string Description, int Quantity, decimal Price, Guid CategoryId);
