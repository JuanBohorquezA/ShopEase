using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopEase.Application.Features.Products.Commands.CreateProduct;
using ShopEase.Application.Features.Products.Commands.DeleteProduct;
using ShopEase.Application.Features.Products.Commands.UpdateProduct;
using ShopEase.Application.Features.Products.Queries.GetProductById;
using ShopEase.WebApi.Controllers.Base;

namespace ShopEase.Presentation.Controllers;

[Route("api/products")]
public class ProductsController : ApiController
{
    public ProductsController(ISender sender)
        : base(sender) { }


    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductById(GetProductByIdQuery query, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(query, cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> RegisterProduct([FromBody] CreateProductCommand command, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(command, cancellationToken);
        return result.Success? Created() : NotFound(result.ErrorMessage);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductCommand command, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(command, cancellationToken);
        return result.Success ? Ok() : NotFound(result.ErrorMessage);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveProduct([FromBody] DeleteProductCommand command, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(command, cancellationToken);
        return result.Success ? NoContent() : NotFound(result.ErrorMessage);
    }

}
