using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CEM.DAL.Repositories
{
    public class RepositoryFor<TEntity> : IRepositoryFor<TEntity> where TEntity : class
    {
        protected ApplicationContext context;
        public RepositoryFor(ApplicationContext context) => this.context = context;

        public virtual TEntity Create(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
            return entity;
        }

        public virtual async Task<TEntity> GetAsync(long id) => await context.Set<TEntity>().FindAsync(id).ConfigureAwait(false);

        public virtual TEntity Get(Expression<Func<TEntity, bool>> where = null) => GetAll(where).FirstOrDefault();

        public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> where = null) => await GetAll(where).FirstOrDefaultAsync().ConfigureAwait(false);

        public virtual IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> where = null) => where != null ? context.Set<TEntity>().Where(where) : context.Set<TEntity>();

        public virtual TEntity Update(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public IQueryable<T> Set<T>() where T : class => context.Set<T>();


        public async Task<IQueryable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> where = null)
        {
            var all = await GetAll(where).ToListAsync().ConfigureAwait(false);
            return all.AsQueryable();
        }
    }
}
