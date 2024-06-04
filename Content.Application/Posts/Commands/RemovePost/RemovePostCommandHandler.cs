using Content.Application.Common.Contracts.Repositories;
using MediatR;

namespace Content.Application.Posts.Commands.RemovePost;

public class RemovePostCommandHandler(IPostRepository repository) : IRequestHandler<RemovePostCommand, bool>
{
    public async Task<bool> Handle(RemovePostCommand request, CancellationToken cancellationToken)
    {
        return await repository.RemoveAsync(request.Id, cancellationToken);
    }
}