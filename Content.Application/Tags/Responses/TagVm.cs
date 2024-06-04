using AutoMapper;
using BlogPlatform.Service.Common.Mappings;
using Content.Domain.Entities;

namespace Content.Application.Tags.Responses;

public class TagVm : IMapWith<Tag>
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public DateTime CreatedAt { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Tag, TagVm>();
    }
}