using Content.Application.Common.Contracts;
using Content.Domain.Entities;
using Content.Infrastructure.DataProvider.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Content.Infrastructure.DataProvider;

public class ContentDbContext : DbContext, IContentDbContext
{
    public ContentDbContext(DbContextOptions<ContentDbContext> options) : base(options)
    {
    }

    public DbSet<Category> Categories { get; set; }

    public DbSet<Tag> Tags { get; set; }

    public DbSet<Post?> Posts { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new PostConfiguration());
        builder.ApplyConfiguration(new CategoryConfiguration());
        builder.ApplyConfiguration(new TagConfiguration());
        base.OnModelCreating(builder);
    }
}