using Content.Application.Common.Contracts.Repositories;
using FluentValidation;

namespace Content.Application.Categories.Commands.EditCategory;

public class EditCategoryCommandValidator: AbstractValidator<EditCategoryCommand>
{
    public EditCategoryCommandValidator(ICategoryRepository repository)
    {
        RuleFor(p => p.Id)
            .NotEmpty().WithMessage("Требуется идентификатор.")
            .MustAsync(async (id, cancellationToken) =>
            {
                var categoryExists = await repository.ExistsAsync(p => p.Id == id, cancellationToken);
                return categoryExists;
            }).WithMessage("Категория не существует.");

        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("Имя обязательно.")
            .MinimumLength(5).WithMessage("Имя должно состоять не менее чем из 5 символов.")
            .MaximumLength(200).WithMessage("Имя не должно превышать 100 символов.")
            .MustAsync(async (name, cancellationToken) =>
            {
                var categoryExists = await repository.ExistsAsync(p => p.Name == name, cancellationToken);
                return !categoryExists;
            }).WithMessage("Имя должно быть уникальным.");
    }
    
}