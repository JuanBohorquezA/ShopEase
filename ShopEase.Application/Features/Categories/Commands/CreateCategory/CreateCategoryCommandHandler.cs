using ShopEase.Application.Abstractions.Messaging;
using ShopEase.Application.Common;
using ShopEase.Domain.Abstractions;
using ShopEase.Domain.Entities.Main;

namespace ShopEase.Application.Features.Categorys.Commands.CreateCategory;

public class CreateCategoryCommandHandler : ICommandHandler<CreateCategoryCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateCategoryCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle(CreateCategoryCommand command, CancellationToken cancellationToken)
    {
        var category = new Category
        {
            Id = Guid.NewGuid(),
            Name = command.Name,
            Description = command.Description,
        };

        await _unitOfWork.CategoryRepository.InsertAsync(category, cancellationToken);
        await _unitOfWork.SaveAsync(cancellationToken);

        return Result<Guid>.SuccessResult(category.Id);

    }

}
