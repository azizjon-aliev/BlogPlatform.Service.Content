using AutoMapper;
using Content.Application.Common.Contracts.Repositories;
using Content.Application.Tags.Responses;
using Content.Domain.Entities;
using MediatR;

namespace Content.Application.Tags.Commands.AddTag;

public class AddTagCommandHandler(ITagRepository repository, IMapper mapper)
    : IRequestHandler<AddTagCommand, TagDetailVm>
{
    public async Task<TagDetailVm> Handle(AddTagCommand request, CancellationToken cancellationToken)
    {
        var tag = new Tag
        {
            Name = request.Name
        };

        var dbResponse = await repository.AddAsync(tag, cancellationToken);
        return mapper.Map<TagDetailVm>(dbResponse);
    }
}