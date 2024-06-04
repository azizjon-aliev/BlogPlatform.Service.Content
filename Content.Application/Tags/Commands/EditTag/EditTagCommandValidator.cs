using Content.Application.Common.Contracts.Repositories;
using FluentValidation;

namespace Content.Application.Tags.Commands.EditTag;

public class EditTagCommandValidator : AbstractValidator<EditTagCommand>
{
    public EditTagCommandValidator(ITagRepository repository)
    {
        RuleFor(p => p.Id)
            .NotEmpty().WithMessage("Идентификатор обязателен.")
            .MustAsync(async (id, cancellationToken) =>
            {
                var tagExists = await repository.ExistsAsync(p => p.Id == id, cancellationToken);
                return tagExists;
            }).WithMessage("Тег не найден.");

        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("Имя обязательно.")
            .MinimumLength(5).WithMessage("Имя должно содержать не менее 5 символов.")
            .MaximumLength(200).WithMessage("Имя должно содержать не более 200 символов.")
            .MustAsync(async (name, cancellationToken) =>
            {
                var tagExists = await repository.ExistsAsync(p => p.Name == name, cancellationToken);
                return !tagExists;
            }).WithMessage("Тег с таким именем уже существует.");
    }
}