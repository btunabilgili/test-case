using System.Linq.Expressions;

namespace RiskAnalysis.Domain
{
    public interface IRepository<T> where T : BaseEntity, new()
    {
        Task<T> CreateAsync(T entity, CancellationToken cancellationToken = default);
        Task<T> UpdateAsync(T entity, CancellationToken cancellationToken = default);
        Task DeleteAsync(T entity, CancellationToken cancellationToken = default);
        Task<List<T>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<List<T>> FindAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);
        Task<T> GetFirstOrDefault(CancellationToken cancellationToken = default);
    }
}
