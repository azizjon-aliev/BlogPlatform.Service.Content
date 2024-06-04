using AutoMapper;
using BlogPlatform.Service.Common.Extensions;
using Content.Application.Common.Contracts.Repositories;
using Content.Application.Tags.Responses;
using Content.Domain.Entities;
using MediatR;

namespace Content.Application.Tags.Queries.GetTagById;


public class GetTagByIdQueryHandler(ITagRepository repository, IMapper mapper)
    : IRequestHandler<GetTagByIdQuery, TagDetailVm>
{
    public async Task<TagDetailVm> Handle(GetTagByIdQuery request, CancellationToken cancellationToken)
    {
        var dbResponse = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (dbResponse is null)
        {
            throw new NotFoundException(nameof(Tag), request.Id);
        }

        return mapper.Map<TagDetailVm>(dbResponse);
    }
}