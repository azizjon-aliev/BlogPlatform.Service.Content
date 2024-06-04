using Content.Application.Tags.Responses;
using MediatR;

namespace Content.Application.Tags.Queries.GetTagList;

public class GetTagListQuery : IRequest<List<TagVm>>
{
}