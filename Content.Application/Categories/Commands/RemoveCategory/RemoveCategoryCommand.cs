using MediatR;

namespace Content.Application.Categories.Commands.RemoveCategory;

public class RemoveCategoryCommand: IRequest<bool>
{
    public Guid Id { get; set; }
}