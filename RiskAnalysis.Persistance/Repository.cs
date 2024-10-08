using Microsoft.EntityFrameworkCore;
using RiskAnalysis.Domain;
using RiskAnalysis.Persistance.Contexts;
using System.Linq.Expressions;

namespace RiskAnalysis.Persistance
{
    public class Repository<T>(ApplicationDbContext dbContext) : IRepository<T> where T : BaseEntity, new()
    {
        private readonly DbSet<T> _dbSet = dbContext.Set<T>();

        public async Task<T> CreateAsync(T entity, CancellationToken cancellationToken = default)
        {
            await _dbSet.AddAsync(entity, cancellationToken);

            await dbContext.SaveChangesAsync(cancellationToken);

            return entity;
        }

        public async Task<T> UpdateAsync(T entity, CancellationToken cancellationToken = default)
        {
            _dbSet.Update(entity);

            await dbContext.SaveChangesAsync(cancellationToken);

            return entity;
        }

        public async Task DeleteAsync(T entity, CancellationToken cancellationToken = default)
        {
            _dbSet.Remove(entity);

            await dbContext.SaveChangesAsync(cancellationToken);
        }

        public Task<List<T>> FindAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return _dbSet.Where(predicate).ToListAsync(cancellationToken);
        }

        public Task<List<T>> GetAllAsync(Expression<Func<T, object>>? include = null, CancellationToken cancellationToken = default)
        {
            var queryable = _dbSet.AsQueryable();

            if (include is not null)
                queryable = queryable.Include(include);

            return queryable.ToListAsync(cancellationToken);
        }

        public Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return _dbSet.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public Task<T?> GetFirstOrDefault(CancellationToken cancellationToken = default)
        {
            return _dbSet.FirstOrDefaultAsync(cancellationToken);
        }
    }
}
