using ShopEase.Application.Abstractions.Messaging;
using ShopEase.Application.Features.Products.Response;

namespace ShopEase.Application.Features.Products.Queries.GetProductById;

public sealed record GetProductByIdQuery(Guid productId): IQuery<ProductResponse>;
