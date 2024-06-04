using Content.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Content.Infrastructure.DataProvider.EntityTypeConfigurations;

public class TagConfiguration : IEntityTypeConfiguration<Tag>
{
    public void Configure(EntityTypeBuilder<Tag> builder)
    {
        builder.HasKey(c => c.Id);
        builder.HasIndex(c => c.Name).IsUnique();
        builder.Property(c => c.Name).IsRequired().HasMaxLength(100);

        builder.HasMany(c => c.Posts)
            .WithMany(p => p.Tags);

        builder.Property(c => c.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP").ValueGeneratedOnAdd();
        builder.Property(c => c.UpdatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP").ValueGeneratedOnAddOrUpdate();
        builder.Property(c => c.DeletedAt).IsRequired(false);
    }
}