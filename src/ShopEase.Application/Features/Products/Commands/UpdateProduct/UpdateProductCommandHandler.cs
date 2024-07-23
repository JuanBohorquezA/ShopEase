﻿using ShopEase.Application.Abstractions.Messaging;
using ShopEase.Application.Common;
using ShopEase.Domain.Abstractions;

namespace ShopEase.Application.Features.Products.Commands.UpdateProduct;

public class UpdateProductCommandHandler : ICommandHandler<UpdateProductCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;
    public UpdateProductCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
    {
        var ProductToUpdate = await _unitOfWork.ProductRepository.GetByIdAsync(command.productId, cancellationToken);
        if (ProductToUpdate is null)
            return Result<Guid>.FailureResult($"productId {command.productId} does not exist.");
        
        ProductToUpdate.Quantity = command.Quantity;
        ProductToUpdate.Price = command.Price;

        _unitOfWork.ProductRepository.Update(ProductToUpdate, cancellationToken);
        await _unitOfWork.SaveAsync(cancellationToken);

        return Result<Guid>.SuccessResult(ProductToUpdate.Id);
    }
}