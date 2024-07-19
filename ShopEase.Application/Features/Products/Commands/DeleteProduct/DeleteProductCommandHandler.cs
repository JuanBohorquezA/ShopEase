using ShopEase.Application.Abstractions.Messaging;
using ShopEase.Application.Common;
using ShopEase.Domain.Abstractions;

namespace ShopEase.Application.Features.Products.Commands.DeleteProduct;

public class DeleteProductCommandHandler : ICommandHandler<DeleteProductCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    public DeleteProductCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<Result> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _unitOfWork.ProductRepository.GetByIdAsync(request.productId, cancellationToken);
        if (product == null)
            return Result.FailureResult($"Product id {request.productId} does not exist.");

        _unitOfWork.ProductRepository.Delete(product, cancellationToken);
        await _unitOfWork.SaveAsync(cancellationToken);

        return Result.SuccessResult();
    }
}
