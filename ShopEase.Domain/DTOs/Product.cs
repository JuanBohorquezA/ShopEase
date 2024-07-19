namespace ShopEase.Domain.DTOs;

public sealed record CreateProduct(string Name, string Description, int Quantity, decimal Price, Guid CategoryId);
public sealed record UpdateProduct(Guid productId, int Quantity, decimal Price);
public sealed record DeleteProduct(Guid productId);


