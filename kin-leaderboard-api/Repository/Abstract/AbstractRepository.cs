using System.Collections.Generic;
using System.Threading.Tasks;
using kin_leaderboard_api.Entities;
using Microsoft.EntityFrameworkCore;

namespace kin_leaderboard_api.Repository.Abstract
{
    public abstract class AbstractRepository<T> where T : class
    {
        private DbSet<T> _dbSet;
        private DbSet<T> DbSet => _dbSet ?? (_dbSet = Context.Set<T>());

        protected readonly ApplicationContext Context;

        protected AbstractRepository(ApplicationContext context)
        {
            Context = context;
        }

        public virtual Task Add(T entity)
        {
           return DbSet.AddAsync(entity);
        }

        public virtual Task Add(IEnumerable<T> entities)
        {
           return DbSet.AddRangeAsync(entities);
        }

        public virtual async Task<int> Create(T entity)
        {
            await DbSet.AddAsync(entity).ConfigureAwait(false);
            return await SaveChanges().ConfigureAwait(false);
        }

        public virtual Task<int> Delete(T entity)
        {
            DeleteWithoutSave(entity);
            return SaveChanges();
        }

        public virtual void DeleteWithoutSave(T entity)
        {
            if (entity != null)
            {
                DbSet.Remove(entity);
            }
        }

        public virtual Task<int> SaveChanges()
        {
            return Context.SaveChangesAsync();
        }
    }
}
