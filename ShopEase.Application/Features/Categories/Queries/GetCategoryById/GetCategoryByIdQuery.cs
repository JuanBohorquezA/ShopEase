using ShopEase.Application.Abstractions.Messaging;
using ShopEase.Application.Features.Categorys.Response;

namespace ShopEase.Application.Features.Categorys.Queries.GetCategoryById;

public sealed record GetCategoryByIdQuery(Guid CategoryId) : IQuery<CategoryResponse>;
