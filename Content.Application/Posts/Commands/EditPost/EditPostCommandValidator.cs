using Content.Application.Common.Contracts.Repositories;
using FluentValidation;

namespace Content.Application.Posts.Commands.EditPost;

public class EditPostCommandValidator : AbstractValidator<EditPostCommand>
{
    public EditPostCommandValidator(IPostRepository repository, ICategoryRepository categoryRepository)
    {
        RuleFor(x => x.Image)
            .NotEmpty().WithMessage("Изображение обязательно.")
            .Must(x => x.Length > 0).WithMessage("Изображение не должно быть пустым.")
            .Must(x => x.Length < 2097152).WithMessage("Изображение не должно превышать 2MB.")
            .Must(x => x.ContentType.Contains("image")).WithMessage("Изображение должно быть формата изображения.");

        RuleFor(p => p.Id)
            .NotEmpty().WithMessage("Идентификатор обязателен.")
            .MustAsync(async (id, cancellationToken) =>
            {
                var categoryExists = await repository.ExistsAsync(p => p.Id == id, cancellationToken);
                return categoryExists;
            }).WithMessage("Пост не найден.");

        RuleFor(p => p.Title)
            .NotEmpty().WithMessage("Заголовок обязателен.")
            .MinimumLength(5).WithMessage("Заголовок должен содержать не менее 5 символов.")
            .MaximumLength(200).WithMessage("Заголовок не должен превышать 200 символов.")
            .MustAsync(async (title, cancellationToken) =>
            {
                var postExists = await repository.ExistsAsync(p => p.Title == title, cancellationToken);
                return !postExists;
            }).WithMessage("Пост с таким заголовком уже существует.");

        RuleFor(p => p.Content)
            .NotEmpty().WithMessage("Содержание обязательно.")
            .MinimumLength(10).WithMessage("Содержание должно содержать не менее 10 символов.")
            .MaximumLength(5000).WithMessage("Содержание не должно превышать 5000 символов.");

        RuleFor(p => p.CategoryId)
            .NotEmpty().WithMessage("Идентификатор категории обязателен.")
            .MustAsync(async (categoryId, cancellationToken) =>
            {
                var categoryExists = await categoryRepository.ExistsAsync(p => p.Id == categoryId, cancellationToken);
                return categoryExists;
            }).WithMessage("Категория не найдена.");
    }
}