using Content.Application.Posts.Responses;
using MediatR;

namespace Content.Application.Posts.Commands.AddPost;

public class AddPostCommand : IRequest<PostDetailVm>
{
    public string Title { get; set; }
    public string Content { get; set; }
    public Guid CategoryId { get; set; }
}