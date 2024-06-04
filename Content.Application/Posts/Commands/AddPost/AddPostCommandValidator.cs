using Content.Application.Common.Contracts.Repositories;
using FluentValidation;

namespace Content.Application.Posts.Commands.AddPost;

public class AddPostCommandValidator : AbstractValidator<AddPostCommand>
{
    public AddPostCommandValidator(IPostRepository postRepository, ICategoryRepository categoryRepository)
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Загаловок обязателен.")
            .MinimumLength(5).WithMessage("Заголовок должен содержать не менее 5 символов.")
            .MaximumLength(200).WithMessage("Заголовок не должен превышать 200 символов.")
            .MustAsync(async (title, cancellationToken) =>
            {
                var postExists = await postRepository.ExistsAsync(p => p.Title == title, cancellationToken);
                return !postExists;
            }).WithMessage("Пост с таким заголовком уже существует.");

        RuleFor(p => p.CategoryId)
            .NotEmpty().WithMessage("Категория обязательна.")
            .MustAsync(async (categoryId, cancellationToken) =>
            {
                var categoryExists = await categoryRepository.ExistsAsync(c => c.Id == categoryId, cancellationToken);
                return categoryExists;
            }).WithMessage("Категория не существует.");

        RuleFor(x => x.Content)
            .NotEmpty().WithMessage("Контент обязателен.")
            .MinimumLength(10).WithMessage("Контент должен содержать не менее 10 символов.")
            .MaximumLength(5000).WithMessage("Контент не должен превышать 5000 символов.");
    }
}