using Content.Application.Posts.Responses;
using MediatR;

namespace Content.Application.Posts.Queries.GetPostById;

public class GetPostByIdQuery : IRequest<PostDetailVm>
{
    public Guid Id { get; set; }
}