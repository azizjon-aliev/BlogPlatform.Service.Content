using Content.API.DTO;
using Content.Application.Posts.Commands.AddPost;
using Content.Application.Posts.Commands.EditPost;
using Content.Application.Posts.Commands.RemovePost;
using Content.Application.Posts.Queries.GetPostById;
using Content.Application.Posts.Queries.GetPostList;
using Content.Application.Posts.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Content.API.Controllers;

public class PostsController(IMediator mediator): ApiController
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<PostVm>>> GetAll()
    {
        var request = new GetPostsListQuery();
        return Ok(await mediator.Send(request));
    }
    
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PostDetailVm>> GetById(Guid id)
    {
        var request = new GetPostByIdQuery { Id = id };
        var response = await mediator.Send(request);
        return Ok(response);
    }
    
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PostDetailVm>> Create([FromBody] AddPostCommand request)
    {
        var response = await mediator.Send(request);
        return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
    }
    
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PostDetailVm>> Update(Guid id, [FromBody] UpdatePostDto request)
    {
        var command = new EditPostCommand
        {
            Id = id,
            Title = request.Title,
            Content = request.Content,
            CategoryId = request.CategoryId
        };
        var response = await mediator.Send(command);
        return response;
    }
    
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Delete(Guid id)
    {
        var command = new RemovePostCommand { Id = id };
        await mediator.Send(command);
        return NoContent();
    }
}