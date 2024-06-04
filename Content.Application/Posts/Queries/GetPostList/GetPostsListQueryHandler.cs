using AutoMapper;
using Content.Application.Common.Contracts.Repositories;
using Content.Application.Posts.Responses;
using MediatR;

namespace Content.Application.Posts.Queries.GetPostList;

public class GetPostsListQueryHandler(IPostRepository repository, IMapper mapper): IRequestHandler<GetPostsListQuery, List<PostVm>>
{
    public async Task<List<PostVm>> Handle(GetPostsListQuery request, CancellationToken cancellationToken)
    {
        var dbResponse = await repository.GetListAsync(cancellationToken);
        return mapper.Map<List<PostVm>>(dbResponse);
    }
}