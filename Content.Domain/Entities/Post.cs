using BlogPlatform.Service.Common.Entities;

namespace Content.Domain.Entities;

public class Post : BaseEntity
{
    public string ImageUrl { get; set; } = null!;
    public string Title { get; set; } = null!;

    public string Content { get; set; } = null!;

    public Guid CategoryId { get; set; }

    public Category Category { get; } = null!;

    public ICollection<Tag> Tags { get; } = [];
}