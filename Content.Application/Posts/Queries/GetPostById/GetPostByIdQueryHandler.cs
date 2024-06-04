using AutoMapper;
using BlogPlatform.Service.Common.Extensions;
using Content.Application.Common.Contracts.Repositories;
using Content.Application.Posts.Responses;
using Content.Domain.Entities;
using MediatR;

namespace Content.Application.Posts.Queries.GetPostById;

public class GetPostByIdQueryHandler(IPostRepository repository, IMapper mapper)
    : IRequestHandler<GetPostByIdQuery, PostDetailVm>
{
    public async Task<PostDetailVm> Handle(GetPostByIdQuery request, CancellationToken cancellationToken)
    {
        var dbResponse = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (dbResponse is null)
        {
            throw new NotFoundException(nameof(Post), request.Id);
        }

        return mapper.Map<PostDetailVm>(dbResponse);
    }
}
