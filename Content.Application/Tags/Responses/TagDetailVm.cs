using AutoMapper;
using BlogPlatform.Service.Common.Mappings;
using Content.Domain.Entities;

namespace Content.Application.Tags.Responses;

public class TagDetailVm : IMapWith<Tag>
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public ICollection<Post> Posts { get; set; } = [];
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Tag, TagDetailVm>()
            .ForMember(catVm => catVm.Id, opt => opt.MapFrom(cat => cat.Id))
            .ForMember(catVm => catVm.Name, opt => opt.MapFrom(cat => cat.Name))
            .ForMember(catVm => catVm.Posts, opt => opt.MapFrom(cat => cat.Posts))
            .ForMember(catVm => catVm.CreatedAt, opt => opt.MapFrom(cat => cat.CreatedAt))
            .ForMember(catVm => catVm.UpdatedAt, opt => opt.MapFrom(cat => cat.UpdatedAt))
            .ReverseMap();
    }
}