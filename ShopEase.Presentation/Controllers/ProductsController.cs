using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopEase.Application.Features.Products.Commands.CreateProduct;
using ShopEase.Application.Features.Products.Commands.DeleteProduct;
using ShopEase.Application.Features.Products.Commands.UpdateProduct;
using ShopEase.Domain.DTOs;
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
    public async Task<IActionResult> RegisterProduct([FromBody]CreateProduct request, CancellationToken cancellationToken)
    {
        var command = new CreateProductCommand(
            request.Name,
            request.Description,
            request.Quantity,
            request.Price,
            request.CategoryId);

        var result = await Sender.Send(command, cancellationToken);

        return result.Success? Ok() : BadRequest(result.ErrorMessage);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProduct([FromBody]UpdateProduct request, CancellationToken cancellationToken)
    {
        var command = new UpdateProductCommand(
            request.productId,
            request.Quantity,
            request.Price);

        var result = await Sender.Send(command, cancellationToken);
        return result.Success ? Ok() : BadRequest(result.ErrorMessage);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveProduct([FromBody]DeleteProduct request,CancellationToken cancellationToken)
    {
        var command = new DeleteProductCommand(
            request.productId);

        var result = await Sender.Send(command, cancellationToken);

        return result.Success ? Ok() : BadRequest(result.ErrorMessage);
    }

}
