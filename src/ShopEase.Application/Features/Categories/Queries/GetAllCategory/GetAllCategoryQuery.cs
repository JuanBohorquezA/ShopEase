using ShopEase.Application.Abstractions.Messaging;
using ShopEase.Application.Features.Categorys.Response;

namespace ShopEase.Application.Features.Categorys.Queries.GetAllCategory;

public sealed record GetAllCategoryQuery() : IQuery<IEnumerable<CategoryResponse>>;
