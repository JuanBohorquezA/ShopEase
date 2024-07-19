using ShopEase.Application.Abstractions.Messaging;
using ShopEase.Application.Features.Products.Response;

namespace ShopEase.Application.Features.Products.Queries.GetAllProduct;

public sealed record GetAllProductQuery(): IQuery<IEnumerable<ProductResponse>>;
