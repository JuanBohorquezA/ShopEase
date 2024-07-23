﻿using ShopEase.Application.Abstractions.Messaging;
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
    public async Task<Result> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
    {
        var product = await _unitOfWork.ProductRepository.GetByIdAsync(command.productId, cancellationToken);
        if (product is null)
            return Result.FailureResult($"productId {command.productId} does not exist.");

        _unitOfWork.ProductRepository.Delete(product, cancellationToken);
        await _unitOfWork.SaveAsync(cancellationToken);

        return Result.SuccessResult();
    }
}