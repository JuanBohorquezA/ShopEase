﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopEase.Application.Features.Products.Commands.CreateProduct;
using ShopEase.Application.Features.Products.Commands.DeleteProduct;
using ShopEase.WebApi.Controllers.Base;

namespace ShopEase.Presentation.Controllers;

[Route("api/products")]
public class ProductsController : ApiController
{
    public ProductsController(ISender sender) 
        : base(sender)
    {
    }

    [HttpPost]
    public async Task<IActionResult> RegisterProduct(CancellationToken cancellationToken)
    {
        var command = new CreateProductCommand("PAPEL", "PAPEL HIGENICO FAMILIA", 100, 0, new Guid());
        var result = await Sender.Send(command, cancellationToken);

        return result.Success? Ok() : BadRequest(result.ErrorMessage);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveProduct(Guid id,CancellationToken cancellationToken)
    {
        var command = new DeleteProductCommand(id);
        var result = await Sender.Send(command, cancellationToken);

        return result.Success ? Ok() : BadRequest(result.ErrorMessage);
    }
}
