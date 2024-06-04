using AutoMapper;
using Content.Application.Categories.Responses;
using Content.Application.Common.Contracts.Repositories;
using Content.Domain.Entities;
using MediatR;

namespace Content.Application.Categories.Commands.AddCategory;

public class AddCategoryCommandHandler(ICategoryRepository repository, IMapper mapper)
    : IRequestHandler<AddCategoryCommand, CategoryDetailVm>
{
    public async Task<CategoryDetailVm> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = new Category
        {
            Name = request.Name
        };

        var dbResponse = await repository.AddAsync(category, cancellationToken);
        return mapper.Map<CategoryDetailVm>(dbResponse);
    }
}