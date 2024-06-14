using Content.Application.Posts.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Content.Application.Posts.Commands.EditPost;

public class EditPostCommand : IRequest<PostDetailVm>
{
    public Guid Id { get; set; }

    public IFormFile Image { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string Content { get; set; } = null;
    public Guid CategoryId { get; set; }
}