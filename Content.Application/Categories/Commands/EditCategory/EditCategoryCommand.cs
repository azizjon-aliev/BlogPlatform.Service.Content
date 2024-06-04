using Content.Application.Categories.Responses;
using MediatR;

namespace Content.Application.Categories.Commands.EditCategory;

public class EditCategoryCommand : IRequest<CategoryDetailVm>
{
    public Guid Id { get; set; }

    public string Name { get; set; }
}