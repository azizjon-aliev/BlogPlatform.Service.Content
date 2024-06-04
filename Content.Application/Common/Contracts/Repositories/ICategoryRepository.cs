using System.Linq.Expressions;
using Content.Domain.Entities;

namespace Content.Application.Common.Contracts.Repositories;

public interface ICategoryRepository
{
    public Task<Category> AddAsync(Category category, CancellationToken cancellationToken);

    public Task<Category> EditAsync(Guid id, Category category, CancellationToken cancellationToken);

    public Task<bool> RemoveAsync(Guid id, CancellationToken cancellationToken);

    public Task<List<Category>> GetAllAsync(CancellationToken cancellationToken);

    public Task<bool> ExistsAsync(Expression<Func<Category, bool>> predicate, CancellationToken cancellationToken);

    public Task<Category?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
}