using AutoMapper;
using Content.Application.Common.Contracts.Repositories;
using Content.Application.Tags.Responses;
using MediatR;

namespace Content.Application.Tags.Queries.GetTagList;

public class GetTagListQueryHandler(ITagRepository repository, IMapper mapper)
    : IRequestHandler<GetTagListQuery, List<TagVm>>
{
    public async Task<List<TagVm>> Handle(GetTagListQuery request, CancellationToken cancellationToken)
    {
        var dbResponse = await repository.GetAllAsync(cancellationToken);
        return mapper.Map<List<TagVm>>(dbResponse);
    }
}