using AutoMapper;
using Content.Application.Categories.Responses;
using Content.Application.Common.Contracts.Repositories;
using Content.Domain.Entities;
using MediatR;

namespace Content.Application.Categories.Commands.EditCategory;

public class EditCategoryCommandHandler(ICategoryRepository repository, IMapper mapper): IRequestHandler<EditCategoryCommand, CategoryDetailVm>
{
    public async Task<CategoryDetailVm> Handle(EditCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = new Category
        {
            Id = request.Id,
            Name = request.Name
        };
        var dbResponse = await repository.EditAsync(request.Id, category, cancellationToken);
        return mapper.Map<CategoryDetailVm>(dbResponse);
    }
}