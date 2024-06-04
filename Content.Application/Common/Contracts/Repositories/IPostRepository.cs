using System.Linq.Expressions;
using Content.Domain.Entities;

namespace Content.Application.Common.Contracts.Repositories;

public interface IPostRepository
{
    public Task<List<Post>> GetListAsync(CancellationToken cancellationToken);
    
    public Task<Post> GetByIdAsync(Guid id, CancellationToken cancellationToken);

    public Task<Post> AddAsync(Post post, CancellationToken cancellationToken);

    public Task<Post> EditAsync(Guid id, Post post, CancellationToken cancellationToken);

    public Task<bool> RemoveAsync(Guid id, CancellationToken cancellationToken);

    public Task<bool> ExistsAsync(Expression<Func<Post, bool>> predicate, CancellationToken cancellationToken);
}