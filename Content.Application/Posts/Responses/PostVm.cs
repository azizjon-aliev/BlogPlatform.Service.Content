using AutoMapper;
using BlogPlatform.Service.Common.Mappings;
using Content.Domain.Entities;

namespace Content.Application.Posts.Responses;

public class PostVm : IMapWith<Post>
{
    public Guid Id { get; set; }

    public string ImageUrl { get; set; }
    public string Title { get; set; }

    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Post, PostVm>().ReverseMap()
            .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
            .ForMember(d => d.Title, opt => opt.MapFrom(s => s.Title))
            .ForMember(d => d.CreatedAt, opt => opt.MapFrom(s => s.CreatedAt));
    }
}