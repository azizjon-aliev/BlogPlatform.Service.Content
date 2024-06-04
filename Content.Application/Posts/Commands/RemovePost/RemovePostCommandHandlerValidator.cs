using Content.Application.Common.Contracts.Repositories;
using FluentValidation;

namespace Content.Application.Posts.Commands.RemovePost;

public class RemovePostCommandHandlerValidator : AbstractValidator<RemovePostCommand>
{
    public RemovePostCommandHandlerValidator(IPostRepository repository)
    {
        RuleFor(p => p.Id)
            .NotEmpty().WithMessage("Требуется идентификатор.")
            .MustAsync(async (id, cancellationToken) =>
            {
                var postExists = await repository.ExistsAsync(p => p.Id == id, cancellationToken);
                return postExists;
            }).WithMessage("Пост не существует.");
    }
}