using Content.Application.Posts.Responses;
using MediatR;

namespace Content.Application.Posts.Queries.GetPostList;

public class GetPostsListQuery: IRequest<List<PostVm>>
{
    
}