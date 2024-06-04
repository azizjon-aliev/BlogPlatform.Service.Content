using Content.API.DTO;
using Content.Application.Tags.Commands.AddTag;
using Content.Application.Tags.Commands.EditTag;
using Content.Application.Tags.Commands.RemoveTag;
using Content.Application.Tags.Queries.GetTagById;
using Content.Application.Tags.Queries.GetTagList;
using Content.Application.Tags.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Content.API.Controllers;

public class TagsController(IMediator mediator) : ApiController
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<TagVm>>> GetAll()
    {
        var request = new GetTagListQuery();
        return Ok(await mediator.Send(request));
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TagDetailVm>> GetById(Guid id)
    {
        var request = new GetTagByIdQuery { Id = id };
        var response = await mediator.Send(request);
        return Ok(response);
    }


    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TagVm>> Create([FromBody] AddTagCommand request)
    {
        var response = await mediator.Send(request);
        return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TagDetailVm>> Update(Guid id, [FromBody] UpdateTagDto request)
    {
        var command = new EditTagCommand { Id = id, Name = request.Name };
        var response = await mediator.Send(command);
        return response;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Delete(Guid id)
    {
        var command = new RemoveTagCommand { Id = id };
        await mediator.Send(command);
        return NoContent();
    }
}