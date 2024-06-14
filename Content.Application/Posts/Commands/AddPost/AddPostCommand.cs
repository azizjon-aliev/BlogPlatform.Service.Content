using Content.Application.Posts.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Content.Application.Posts.Commands.AddPost;

public class AddPostCommand : IRequest<PostDetailVm>
{
    public IFormFile Image { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string Content { get; set; } = null!;
    public Guid CategoryId { get; set; }
}