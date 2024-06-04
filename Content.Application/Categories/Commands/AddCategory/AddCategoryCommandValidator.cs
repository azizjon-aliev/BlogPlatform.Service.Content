using Content.Application.Common.Contracts.Repositories;
using FluentValidation;

namespace Content.Application.Categories.Commands.AddCategory;

public class AddCategoryCommandValidator : AbstractValidator<AddCategoryCommand>
{
    public AddCategoryCommandValidator(ICategoryRepository repository)
    {
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("Имя не может быть пустым")
            .MinimumLength(5).WithMessage("Имя должно состоять не менее чем из 5 символов.")
            .MaximumLength(200).WithMessage("Имя не должно превышать 100 символов.")
            .MustAsync(async (name, cancellationToken) =>
            {
                var categoryExists = await repository.ExistsAsync(p => p.Name == name, cancellationToken);
                return !categoryExists;
            }).WithMessage("Имя должно быть уникальным.");
    }
}