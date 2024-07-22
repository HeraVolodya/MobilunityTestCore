using MediatR;
using Microsoft.AspNetCore.Mvc;
using TestHeraCategory.Core.BL.Queries.Categories.GetAll;
using TestHeraCategory.Core.BL.Responses.Category;

namespace TestHeraCategory.Controllers;

[Route("api/category")]
public class CategoryController : ControllerBase
{
    private readonly IMediator _mediator;

    public CategoryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("get-all")]
    public async Task<ActionResult<List<CategoryResponse>>> GetAll(
        [FromQuery] string searchTerm)
    {
        var result = await _mediator.Send(new GetAllCategoriesQuery
        {
            SearchTerm = searchTerm
        });

        if (result.Count == 0)
            return NotFound("No categories found.");

        return Ok(result);
    }
}