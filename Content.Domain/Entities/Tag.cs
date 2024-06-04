using BlogPlatform.Service.Common.Entities;

namespace Content.Domain.Entities;

public class Tag : BaseEntity
{
    public required string Name { get; set; }

    public ICollection<Post> Posts { get; } = [];
}