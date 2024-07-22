
using ShopEase.Application.Abstractions.Messaging;
using ShopEase.Application.Common;
using ShopEase.Application.Features.Categorys.Response;
using ShopEase.Domain.Abstractions;

namespace ShopEase.Application.Features.Categorys.Queries.GetAllCategory;

public class GetAllCategoryQueryHandler : IQueryHandler<GetAllCategoryQuery, IEnumerable<CategoryResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllCategoryQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<IEnumerable<CategoryResponse>>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
    {
        var category = await _unitOfWork.CategoryRepository.GetAsync();
        var categoryResponse = category.Select(category => new CategoryResponse(
            category.Id,
            category.Name,
            category.Description));

        return Result<IEnumerable<CategoryResponse>>.SuccessResult(categoryResponse);
    }
}
