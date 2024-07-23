using ShopEase.Application.Abstractions.Messaging;
using ShopEase.Application.Common;
using ShopEase.Domain.Abstractions;

namespace ShopEase.Application.Features.Categorys.Commands.DeleteCategory;

public class DeleteCategoryCommandHandler : ICommandHandler<DeleteCategoryCommand>
{
    private readonly IUnitOfWork _unitOfWork;
public DeleteCategoryCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteCategoryCommand command, CancellationToken cancellationToken)
    {
        var category = await _unitOfWork.CategoryRepository.GetByIdAsync(command.CategoryId, cancellationToken);
        if (category is null)
            return Result.FailureResult($"CategoryId {command.CategoryId} does not exist.");

        _unitOfWork.CategoryRepository.Delete(category, cancellationToken);
        await _unitOfWork.SaveAsync(cancellationToken);
        
        return Result.SuccessResult();
    }
}
