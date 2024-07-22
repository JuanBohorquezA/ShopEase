using ShopEase.Application.Abstractions.Messaging;

namespace ShopEase.Application.Features.Categorys.Commands.DeleteCategory;

public sealed record DeleteCategoryCommand(Guid CategoryId) : ICommand;
