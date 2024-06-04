using Content.API.DTO;
using Content.Application.Categories.Commands.AddCategory;
using Content.Application.Categories.Commands.EditCategory;
using Content.Application.Categories.Commands.RemoveCategory;
using Content.Application.Categories.Queries.GetCategoryById;
using Content.Application.Categories.Queries.GetCategoryList;
using Content.Application.Categories.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Content.API.Controllers;

public class CategoriesController(IMediator mediator): ApiController
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<CategoryVm>>> GetAll()
    {
        var request = new GetCategoryListQuery();
        return Ok(await mediator.Send(request));
    }
    
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CategoryDetailVm>> GetById(Guid id)
    {
        var request = new GetCategoryByIdQuery { Id = id };
        var response = await mediator.Send(request);
        return Ok(response);
    }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CategoryVm>> Create([FromBody] AddCategoryCommand request)
    {
        var response = await mediator.Send(request);
        return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
    }
    
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CategoryDetailVm>> Update(Guid id, [FromBody] UpdateCategoryDto request)
    {
        var command = new EditCategoryCommand { Id = id, Name = request.Name };
        var response = await mediator.Send(command);
        return response;
    }
    
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Delete(Guid id)
    {
        var command = new RemoveCategoryCommand { Id = id };
        await mediator.Send(command);
        return NoContent();
    }
}