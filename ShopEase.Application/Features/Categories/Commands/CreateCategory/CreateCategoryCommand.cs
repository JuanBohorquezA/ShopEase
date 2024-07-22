using ShopEase.Application.Abstractions.Messaging;

namespace ShopEase.Application.Features.Categorys.Commands.CreateCategory;

public sealed record CreateCategoryCommand(string Name, string Description) : ICommand<Guid>;
