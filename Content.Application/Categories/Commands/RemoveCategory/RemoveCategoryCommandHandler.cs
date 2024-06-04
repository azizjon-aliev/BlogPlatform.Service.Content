using Content.Application.Common.Contracts.Repositories;
using MediatR;

namespace Content.Application.Categories.Commands.RemoveCategory;

public class RemoveCategoryCommandHandler(ICategoryRepository repository) : IRequestHandler<RemoveCategoryCommand, bool>
{
    public async Task<bool> Handle(RemoveCategoryCommand request, CancellationToken cancellationToken)
    {
        return await repository.RemoveAsync(request.Id, cancellationToken);
    }
}