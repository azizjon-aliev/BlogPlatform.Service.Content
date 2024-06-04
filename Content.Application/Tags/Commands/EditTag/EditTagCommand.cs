using Content.Application.Tags.Responses;
using MediatR;

namespace Content.Application.Tags.Commands.EditTag;

public class EditTagCommand : IRequest<TagDetailVm>
{
    public Guid Id { get; set; }

    public string Name { get; set; }
}