using System.Linq.Expressions;
using Content.Domain.Entities;

namespace Content.Application.Common.Contracts.Repositories;

public interface ITagRepository
{
    public Task<Tag> AddAsync(Tag tag, CancellationToken cancellationToken);

    public Task<Tag> EditAsync(Guid id, Tag tag, CancellationToken cancellationToken);

    public Task<bool> RemoveAsync(Guid id, CancellationToken cancellationToken);

    public Task<List<Tag>> GetAllAsync(CancellationToken cancellationToken);

    public Task<bool> ExistsAsync(Expression<Func<Tag, bool>> predicate, CancellationToken cancellationToken);

    public Task<Tag?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
}