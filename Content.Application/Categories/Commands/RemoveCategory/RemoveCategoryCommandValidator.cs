using Content.Application.Common.Contracts.Repositories;
using FluentValidation;

namespace Content.Application.Categories.Commands.RemoveCategory;

public class RemoveCategoryCommandValidator : AbstractValidator<RemoveCategoryCommand>
{
    public RemoveCategoryCommandValidator(ICategoryRepository repository)
    {
        RuleFor(p => p.Id)
            .NotEmpty().WithMessage("Требуется идентификатор.")
            .MustAsync(async (id, cancellationToken) =>
            {
                var categoryExists = await repository.ExistsAsync(p => p.Id == id, cancellationToken);
                return categoryExists;
            }).WithMessage("Категория не существует.");
    }
}