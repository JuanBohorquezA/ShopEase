﻿using ShopEase.Application.Abstractions.Messaging;
using ShopEase.Application.Common;
using ShopEase.Domain.Abstractions;
using ShopEase.Domain.Entities.Main;

namespace ShopEase.Application.Features.Products.Commands.CreateProduct;

public class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateProductCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        var category = await _unitOfWork.CategoryRepository.GetByIdAsync(command.CategoryId, cancellationToken);

        if (category is null)
            return Result<Guid>.FailureResult($"Category id {command.CategoryId} does not exist.");

        var product = new Product
        {
            Id = Guid.NewGuid(),
            Name = command.Name,
            Description = command.Description,
            Quantity = command.Quantity,
            Price = command.Price,
            CategoryId = category.Id,
        };

        await _unitOfWork.ProductRepository.InsertAsync(product, cancellationToken);
        await _unitOfWork.SaveAsync(cancellationToken);

        return Result<Guid>.SuccessResult(product.Id);

    }

}