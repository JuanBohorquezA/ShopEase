using ShopEase.Application.Abstractions.Messaging;
using ShopEase.Application.Common;
using ShopEase.Application.Features.Products.Response;
using ShopEase.Domain.Abstractions;

namespace ShopEase.Application.Features.Products.Queries.GetProductById;

public class GetProductByIdQueryHandler : IQueryHandler<GetProductByIdQuery, ProductResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetProductByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<ProductResponse>> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
    {
        var product = await _unitOfWork.ProductRepository.GetByIdAsync(query.productId, cancellationToken);
        if (product is null)
            return Result<ProductResponse>.FailureResult($"productId {query.productId} does not exist.");
        var productResult = new ProductResponse(
            product.Id,
            product.Name,
            product.Description,
            product.Quantity,
            product.Price,
            product.CategoryId);
        
        return Result<ProductResponse>.SuccessResult(productResult);
    }
}
