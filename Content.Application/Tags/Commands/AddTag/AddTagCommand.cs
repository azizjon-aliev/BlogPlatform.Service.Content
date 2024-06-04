using Content.Application.Tags.Responses;
using MediatR;

namespace Content.Application.Tags.Commands.AddTag;

public class AddTagCommand : IRequest<TagDetailVm>
{
    public string Name { get; set; }
}