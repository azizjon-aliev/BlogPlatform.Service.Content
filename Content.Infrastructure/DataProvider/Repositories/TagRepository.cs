using System.Linq.Expressions;
using BlogPlatform.Service.Common.Extensions;
using Content.Application.Common.Contracts;
using Content.Application.Common.Contracts.Repositories;
using Content.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Content.Infrastructure.DataProvider.Repositories;

public class TagRepository(IContentDbContext dbContext) : ITagRepository
{
    public async Task<Tag> AddAsync(Tag tag, CancellationToken cancellationToken)
    {
        await dbContext.Tags.AddAsync(tag, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
        return tag;
    }

    public async Task<Tag> EditAsync(Guid id, Tag tag, CancellationToken cancellationToken)
    {
        var existingTag = await dbContext.Tags.FindAsync(id, cancellationToken);

        if (existingTag == null)
        {
            throw new NotFoundException(nameof(Tag), id);
        }

        existingTag.Name = tag.Name;
        await dbContext.SaveChangesAsync(cancellationToken);
        return existingTag;
    }

    public async Task<bool> RemoveAsync(Guid id, CancellationToken cancellationToken)
    {
        var tag = await dbContext.Tags.FindAsync(id, cancellationToken);

        if (tag == null)
        {
            throw new NotFoundException(nameof(Tag), id);
        }

        dbContext.Tags.Remove(tag);
        await dbContext.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<List<Tag>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await dbContext.Tags.ToListAsync(cancellationToken);
    }

    public async Task<bool> ExistsAsync(Expression<Func<Tag, bool>> predicate, CancellationToken cancellationToken)
    {
        return await dbContext.Tags.AnyAsync(predicate, cancellationToken);
    }

    public async Task<Tag?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await dbContext.Tags.FindAsync(id, cancellationToken);
    }
}