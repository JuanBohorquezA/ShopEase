using ShopEase.Application.Abstractions.Messaging;
using ShopEase.Application.Common;
using ShopEase.Domain.Abstractions;

namespace ShopEase.Application.Features.Categorys.Commands.UpdateCategory;

public class UpdateCategoryCommandHandler : ICommandHandler<UpdateCategoryCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCategoryCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle(UpdateCategoryCommand command, CancellationToken cancellationToken)
    {
        var category = await _unitOfWork.CategoryRepository.GetByIdAsync(command.CategoryId, cancellationToken);
        if (category is null)
            return Result<Guid>.FailureResult($"CategoryId {command.CategoryId} does not exist.");
        
        category.Name = command.Name;
        category.Description = command.Description;

        _unitOfWork.CategoryRepository.Update(category, cancellationToken);
        await _unitOfWork.SaveAsync(cancellationToken);

        return Result<Guid>.SuccessResult(category.Id);
        
    }
}
