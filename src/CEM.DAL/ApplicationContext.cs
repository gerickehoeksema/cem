using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using CEM.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using System;
using System.Reflection;

namespace CEM.DAL
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser, ApplicationRole, long>
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {

        }

        #region ENTITIES
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Entities.Task> Tasks { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<EmployeeLevel> EmployeeLevels { get; set; }
        public DbSet<EmployeeTask> EmployeeTasks { get; set; }
        public DbSet<EmployeeTaskEntry> EmployeeTaskEntries { get; set; }
        #endregion ENTITIES

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                // TODO: Get userID
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.DateCreated = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.DateUpdated = DateTime.Now;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
