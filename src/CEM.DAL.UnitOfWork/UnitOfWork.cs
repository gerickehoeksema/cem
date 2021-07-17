using CEM.DAL.Repositories;
using System.Threading.Tasks;

namespace CEM.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        protected ApplicationContext context;
        public UnitOfWork(ApplicationContext context) => this.context = context;

        public void Dispose()
        {
            context?.Dispose();
        }

        public IRepositoryFor<TEntity> RepositoryFor<TEntity>() where TEntity : class => new RepositoryFor<TEntity>(context);

        public async Task<bool> SaveChangesAsync()
        {
            try
            {
                return await context.SaveChangesAsync().ConfigureAwait(false) > 0;
            }
            catch
            {
                throw;
            }
        }
    }
}
