using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopEase.Application.Features.Products.Commands.CreateProduct;
using ShopEase.Application.Features.Products.Commands.DeleteProduct;
using ShopEase.Application.Features.Products.Commands.UpdateProduct;
using ShopEase.Application.Features.Products.Queries.GetAllProduct;
using ShopEase.Application.Features.Products.Queries.GetProductById;
using ShopEase.WebApi.Controllers.Base;

namespace ShopEase.Presentation.Controllers;

[Route("api/products")]
public class ProductsController : ApiController
{
    public ProductsController(ISender sender)
        : base(sender) { }


    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductById(Guid id, CancellationToken cancellationToken)
    {
        var query = new GetProductByIdQuery(id);
        var result = await Sender.Send(query, cancellationToken);
        return result.Success? Ok(result) : NotFound(result.ErrorMessage);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProducts()
    {
        var query = new GetAllProductQuery();
        var result = await Sender.Send(query);
        return Ok(result.Data);
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
    public async Task<IActionResult> RemoveProduct(Guid id, CancellationToken cancellationToken)
    {
        var command = new DeleteProductCommand(id);
        var result = await Sender.Send(command, cancellationToken);
        return result.Success ? NoContent() : NotFound(result.ErrorMessage);
    }

}
