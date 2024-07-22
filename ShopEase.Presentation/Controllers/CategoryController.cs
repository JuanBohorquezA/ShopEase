using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopEase.Application.Features.Categorys.Commands.CreateCategory;
using ShopEase.Application.Features.Categorys.Commands.DeleteCategory;
using ShopEase.Application.Features.Categorys.Commands.UpdateCategory;
using ShopEase.Application.Features.Categorys.Queries.GetAllCategory;
using ShopEase.Application.Features.Categorys.Queries.GetCategoryById;
using ShopEase.Application.Features.Products.Commands.CreateProduct;
using ShopEase.Application.Features.Products.Commands.DeleteProduct;
using ShopEase.Application.Features.Products.Commands.UpdateProduct;
using ShopEase.Application.Features.Products.Queries.GetProductById;
using ShopEase.WebApi.Controllers.Base;

namespace ShopEase.Presentation.Controllers;

[Route("api/categories")]
public class CategoryController : ApiController
{
    public CategoryController(ISender sender) :
        base(sender){ }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCategoryById(Guid id, CancellationToken cancellationToken)
    {
        var query = new GetCategoryByIdQuery(id);
        var result = await Sender.Send(query, cancellationToken);
        return result.Success ? Ok(result.Data) : NotFound(result.ErrorMessage);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCategories()
    {
        var query = new GetAllCategoryQuery();
        var result = await Sender.Send(query);
        return Ok(result.Data);
    }

    [HttpPost]
    public async Task<IActionResult> RegisterCategory([FromBody] CreateCategoryCommand command, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(command, cancellationToken);
        if (!result.Success)
            return NotFound(result.ErrorMessage);

        return await HandleGetDTO(result.Data, cancellationToken);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCategory([FromBody] UpdateCategoryCommand command, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(command, cancellationToken);
        if (!result.Success)
            return NotFound(result.ErrorMessage);

        return await HandleGetDTO(result.Data, cancellationToken);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveCategory(Guid id, CancellationToken cancellationToken)
    {
        var command = new DeleteCategoryCommand(id);
        var result = await Sender.Send(command, cancellationToken);
        return result.Success ? NoContent() : NotFound(result.ErrorMessage);
    }

    #region private methods
    private async Task<IActionResult> HandleGetDTO(Guid id, CancellationToken cancellationToken)
    {
        var queryGetById = new GetCategoryByIdQuery(id);
        var productResult = await Sender.Send(queryGetById, cancellationToken);

        return productResult.Success ?
            Ok(productResult.Data) :
            NotFound(productResult.ErrorMessage);
    }
    #endregion
}
