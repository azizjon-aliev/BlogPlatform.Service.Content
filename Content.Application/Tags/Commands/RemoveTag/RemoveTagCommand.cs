using MediatR;

namespace Content.Application.Tags.Commands.RemoveTag;

public class RemoveTagCommand : IRequest<bool>
{
    public Guid Id { get; set; }
}