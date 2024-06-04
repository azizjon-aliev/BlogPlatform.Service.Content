using Content.Application.Posts.Responses;
using MediatR;

namespace Content.Application.Posts.Commands.EditPost;

public class EditPostCommand : IRequest<PostDetailVm>
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public Guid CategoryId { get; set; }
}