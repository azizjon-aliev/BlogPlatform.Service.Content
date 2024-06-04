using Content.Application.Tags.Responses;
using MediatR;

namespace Content.Application.Tags.Queries.GetTagById;

public class GetTagByIdQuery : IRequest<TagDetailVm>
{
    public Guid Id { get; set; }
}