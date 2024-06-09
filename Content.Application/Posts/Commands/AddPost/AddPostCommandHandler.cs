using AutoMapper;
using Content.Application.Common.Contracts.Providers;
using Content.Application.Common.Contracts.Repositories;
using Content.Application.Posts.Responses;
using Content.Domain.Entities;
using MediatR;

namespace Content.Application.Posts.Commands.AddPost;

public class AddPostCommandHandler(
    IPostRepository postRepository,
    IMapper mapper,
    IFileProvider fileProvider
) : IRequestHandler<AddPostCommand, PostDetailVm>
{
    public async Task<PostDetailVm> Handle(AddPostCommand request, CancellationToken cancellationToken)
    {
        var imageUrl = await fileProvider.SaveFileAsync(request.Image, cancellationToken);

        var post = new Post
        {
            ImageUrl = imageUrl,
            Title = request.Title,
            Content = request.Content,
            CategoryId = request.CategoryId
        };

        var dbResponse = await postRepository.AddAsync(post, cancellationToken);
        return mapper.Map<PostDetailVm>(dbResponse);
    }
}