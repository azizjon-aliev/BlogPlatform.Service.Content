using AutoMapper;
using BlogPlatform.Service.Common.Mappings;
using Content.Domain.Entities;

namespace Content.Application.Categories.Responses;

public class CategoryVm : IMapWith<Category>
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public DateTime CreatedAt { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Category, CategoryVm>();
    }
}