using Content.Application.Common.Contracts.Repositories;
using MediatR;

namespace Content.Application.Tags.Commands.RemoveTag;

public class RemoveTagCommandHandler(ITagRepository repository) : IRequestHandler<RemoveTagCommand, bool>
{
    public async Task<bool> Handle(RemoveTagCommand request, CancellationToken cancellationToken)
    {
        return await repository.RemoveAsync(request.Id, cancellationToken);
    }
}