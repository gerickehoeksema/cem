using CEM.DAL.Repositories;
using System;
using System.Threading.Tasks;

namespace CEM.DAL.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepositoryFor<TEntity> RepositoryFor<TEntity>() where TEntity : class;

        Task<bool> SaveChangesAsync();
    }
}
