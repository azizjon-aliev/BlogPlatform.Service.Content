using Content.Application.Categories.Responses;
using MediatR;

namespace Content.Application.Categories.Commands.AddCategory;

public class AddCategoryCommand: IRequest<CategoryDetailVm>
{
    public string Name { get; set; }
}