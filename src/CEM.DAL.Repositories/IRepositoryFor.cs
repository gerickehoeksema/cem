using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CEM.DAL.Repositories
{
    public interface IRepositoryFor<TEntity>
    {
        TEntity Create(TEntity entity);

        TEntity Update(TEntity entity);

        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> where = null);

        TEntity Get(Guid id);

        Task<TEntity> GetAsync(Guid id);

        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> where = null);

        Task<IQueryable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> where = null);

        IQueryable<T> Set<T>() where T : class;
    }
}
