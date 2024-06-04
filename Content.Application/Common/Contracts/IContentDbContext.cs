using Content.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Content.Application.Common.Contracts;

public interface IContentDbContext
{
    DbSet<Category> Categories { get; set; }
    DbSet<Post> Posts { get; set; }
    DbSet<Tag> Tags { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}