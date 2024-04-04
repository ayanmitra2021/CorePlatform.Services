using Ardalis.GuardClauses;
using Ardalis.Specification;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CorePlatform.Services.Infrastructure.Repository
{
    public class GenericRepository<TEntity> where TEntity : class
    {
        private DbContext _dbContext;
        private DbSet<TEntity> _dbSet;
        public GenericRepository(DbContext context) 
        {
            this._dbContext = context;
            this._dbSet = context.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> Get(            
            Expression<Func<TEntity, bool>> filter = null, 
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = ""
            )
        {
            IQueryable<TEntity> query = this._dbSet;

            if (filter != null) query = query.Where(filter);

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null) return orderBy(query).ToList();

            return query.ToList();
        }
        public virtual TEntity GetByID(object id)
        {
            Guard.Against.Null(id);
            return _dbSet.Find(id);
        }

        public virtual void Insert(TEntity entity)
        {
            Guard.Against.Null(entity);
            _dbSet.Add(entity);
        }

        public virtual void Delete(object id)
        {
            Guard.Against.Null(id);
            TEntity entityToDelete = _dbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            Guard.Against.Null(entityToDelete);
            if (_dbContext.Entry(entityToDelete).State == EntityState.Detached)
            {
               _dbSet.Attach(entityToDelete);
            }
            _dbSet.Remove(entityToDelete);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            _dbSet.Attach(entityToUpdate);
            _dbContext.Entry(entityToUpdate).State = EntityState.Modified;
        }
    }
}
