using Content.Application.Categories.Commands.RemoveCategory;
using Content.Application.Common.Contracts.Repositories;
using FluentValidation;

namespace Content.Application.Tags.Commands.RemoveTag;

public class RemoveTagCommandValidator : AbstractValidator<RemoveTagCommand>
{
    public RemoveTagCommandValidator(ITagRepository repository)
    {
        RuleFor(p => p.Id)
            .NotEmpty().WithMessage("Идентификатор тега не может быть пустым.")
            .MustAsync(async (id, cancellationToken) =>
            {
                var tagExists = await repository.ExistsAsync(p => p.Id == id, cancellationToken);
                return tagExists;
            }).WithMessage("Тег с указанным идентификатором не найден.");
    }
}