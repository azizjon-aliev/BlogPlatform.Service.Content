using AutoMapper;
using BlogPlatform.Service.Common.Mappings;
using Content.Domain.Entities;

namespace Content.Application.Posts.Responses;

public class PostDetailVm : IMapWith<Post>
{
    public string Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public Category Category { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Post, PostDetailVm>()
            .ForMember(postVm => postVm.Id, opt => opt.MapFrom(post => post.Id))
            .ForMember(postVm => postVm.Title, opt => opt.MapFrom(post => post.Title))
            .ForMember(postVm => postVm.Content, opt => opt.MapFrom(post => post.Content))
            .ForMember(postVm => postVm.Category, opt => opt.MapFrom(post => post.Category))
            .ForMember(postVm => postVm.CreatedAt, opt => opt.MapFrom(post => post.CreatedAt))
            .ForMember(postVm => postVm.UpdatedAt, opt => opt.MapFrom(post => post.UpdatedAt))
            .ReverseMap();
    }
}