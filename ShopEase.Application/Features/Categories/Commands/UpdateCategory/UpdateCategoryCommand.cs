using ShopEase.Application.Abstractions.Messaging;
using ShopEase.Application.Features.Categorys.Response;

namespace ShopEase.Application.Features.Categorys.Commands.UpdateCategory;

public sealed record UpdateCategoryCommand(Guid CategoryId, string Name, string Description) : ICommand<Guid>;
