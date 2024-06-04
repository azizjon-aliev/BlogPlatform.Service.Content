using MediatR;

namespace Content.Application.Posts.Commands.RemovePost;

public class RemovePostCommand: IRequest<bool>
{
    public Guid Id { get; set; }
}