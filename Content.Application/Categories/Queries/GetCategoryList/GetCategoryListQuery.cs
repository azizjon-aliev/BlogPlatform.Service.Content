using Content.Application.Categories.Responses;
using MediatR;

namespace Content.Application.Categories.Queries.GetCategoryList;

public class GetCategoryListQuery:  IRequest<List<CategoryVm>>
{
    
}