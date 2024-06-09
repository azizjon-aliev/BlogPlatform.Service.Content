using AutoMapper;
using Content.Application.Common.Contracts.Providers;
using Content.Application.Common.Contracts.Repositories;
using Content.Application.Posts.Responses;
using Content.Domain.Entities;
using MediatR;

namespace Content.Application.Posts.Commands.EditPost;

public class EditPostCommandHandler(
    IPostRepository repository,
    IMapper mapper,
    IFileProvider fileProvider) : IRequestHandler<EditPostCommand, PostDetailVm>
{
    public async Task<PostDetailVm> Handle(EditPostCommand request, CancellationToken cancellationToken)
    {
        var imageUrl = await fileProvider.SaveFileAsync(request.Image, cancellationToken);
        var post = new Post
        {
            ImageUrl = imageUrl,
            Title = request.Title,
            Content = request.Content,
            CategoryId = request.CategoryId
        };
        var dbResponse = await repository.EditAsync(request.Id, post, cancellationToken);
        return mapper.Map<PostDetailVm>(dbResponse);
    }
}