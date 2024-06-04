using System.Linq.Expressions;
using BlogPlatform.Service.Common.Extensions;
using Content.Application.Common.Contracts;
using Content.Application.Common.Contracts.Repositories;
using Content.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Content.Infrastructure.DataProvider.Repositories;

public class CategoryRepository(IContentDbContext dbContext): ICategoryRepository
{
    public async Task<Category> AddAsync(Category category, CancellationToken cancellationToken)
    {
        await dbContext.Categories.AddAsync(category, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
        return category;
    }

    public async Task<Category> EditAsync(Guid id, Category category, CancellationToken cancellationToken)
    {
        var existingCategory = await dbContext.Categories.FindAsync(id, cancellationToken);
        
        if (existingCategory == null)
        {
            throw new NotFoundException(nameof(Category), id);
        }

        existingCategory.Name = category.Name;
        await dbContext.SaveChangesAsync(cancellationToken);
        return existingCategory;
    }

    public async Task<bool> RemoveAsync(Guid id, CancellationToken cancellationToken)
    {
        var category = await dbContext.Categories.FindAsync(id, cancellationToken);
        
        if (category == null)
        {
            throw new NotFoundException(nameof(Category), id);
        }

        dbContext.Categories.Remove(category);
        await dbContext.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<List<Category>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await dbContext.Categories.ToListAsync(cancellationToken);
    }

    public async Task<bool> ExistsAsync(Expression<Func<Category, bool>> predicate, CancellationToken cancellationToken)
    {
        return await dbContext.Categories.AnyAsync(predicate, cancellationToken);
    }

    public async Task<Category?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await dbContext.Categories.FindAsync(id, cancellationToken);
    }
}