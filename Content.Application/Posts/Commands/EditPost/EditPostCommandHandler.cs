using AutoMapper;
using Content.Application.Common.Contracts.Repositories;
using Content.Application.Posts.Responses;
using Content.Domain.Entities;
using MediatR;

namespace Content.Application.Posts.Commands.EditPost;

public class EditPostCommandHandler(IPostRepository repository, IMapper mapper): IRequestHandler<EditPostCommand, PostDetailVm>
{
    public async Task<PostDetailVm> Handle(EditPostCommand request, CancellationToken cancellationToken)
    {
        var post = new Post
        {
            Title = request.Title,
            Content = request.Content,
            CategoryId = request.CategoryId
        };
        var dbResponse = await repository.EditAsync(request.Id, post, cancellationToken);
        return mapper.Map<PostDetailVm>(dbResponse);
    }
}