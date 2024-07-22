using ShopEase.Application.Abstractions.Messaging;
using ShopEase.Application.Common;
using ShopEase.Application.Features.Categorys.Response;
using ShopEase.Domain.Abstractions;

namespace ShopEase.Application.Features.Categorys.Queries.GetCategoryById;

public class GetCategoryByIdQueryHandler : IQueryHandler<GetCategoryByIdQuery, CategoryResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetCategoryByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<CategoryResponse>> Handle(GetCategoryByIdQuery query, CancellationToken cancellationToken)
    {
        var category = await _unitOfWork.CategoryRepository.GetByIdAsync(query.CategoryId, cancellationToken);
        if (category is null)
            return Result<CategoryResponse>.FailureResult($"CategoryId {query.CategoryId} does not exist.");
    
        var categoryResponse = new CategoryResponse(
            category.Id,
            category.Name,
            category.Description);

        return Result<CategoryResponse>.SuccessResult(categoryResponse);
    }
}
