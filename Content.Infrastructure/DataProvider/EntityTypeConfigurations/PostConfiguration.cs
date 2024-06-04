using Content.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Content.Infrastructure.DataProvider.EntityTypeConfigurations;


public class PostConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Title).IsRequired().HasMaxLength(100);
        builder.Property(p => p.Content).IsRequired(false).HasMaxLength(2000);

        builder.HasOne(p => p.Category)
            .WithMany(c => c.Posts)
            .HasForeignKey(p => p.CategoryId);
        
        builder.HasMany(c => c.Tags)
            .WithMany(p => p.Posts);
        
        builder.Property(c => c.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP").ValueGeneratedOnAdd();
        builder.Property(c => c.UpdatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP").ValueGeneratedOnAddOrUpdate();
        builder.Property(c => c.DeletedAt).IsRequired(false);
    }
}