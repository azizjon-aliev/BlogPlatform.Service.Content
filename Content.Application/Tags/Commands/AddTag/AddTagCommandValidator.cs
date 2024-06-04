using Content.Application.Common.Contracts.Repositories;
using FluentValidation;

namespace Content.Application.Tags.Commands.AddTag;

public class AddTagCommandValidator : AbstractValidator<AddTagCommand>
{
    public AddTagCommandValidator(ITagRepository repository)
    {
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("Имя обязательно для заполнения.")
            .MinimumLength(5).WithMessage("Имя должно содержать не менее 5 символов.")
            .MaximumLength(200).WithMessage("Имя должно содержать не более 200 символов.")
            .MustAsync(async (name, cancellationToken) =>
            {
                var tagExists = await repository.ExistsAsync(p => p.Name == name, cancellationToken);
                return !tagExists;
            }).WithMessage("Тег с таким именем уже существует.");
    }
}