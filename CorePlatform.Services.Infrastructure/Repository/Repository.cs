using CorePlatform.Services.Core.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace CorePlatform.Services.Infrastructure.Repository
{
    public abstract class Repository<TEntity>
    where TEntity : EntityBase
    {
        protected readonly ApplicationDBContext _db;

        public Repository(ApplicationDBContext dbContext)
        {
            _db = dbContext;
        }

        public async Task<TEntity?> GetByIdAsync(int Id, CancellationToken ct = default)
        {
            return await _db.Set<TEntity>()
                .FirstOrDefaultAsync(x => x.Id == Id, ct);
        }

        public void Add(TEntity entity)
        {
            _db.Add(entity);
        }
    }
}
