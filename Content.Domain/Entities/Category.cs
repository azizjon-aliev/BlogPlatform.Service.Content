using BlogPlatform.Service.Common.Entities;

namespace Content.Domain.Entities;

public class Category: BaseEntity
{
    public string Name { get; set; }
		
    public ICollection<Post> Posts { get; } = [];
}