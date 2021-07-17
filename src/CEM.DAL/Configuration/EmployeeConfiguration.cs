using CEM.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CEM.DAL.Configuration
{
    public class EmployeeConfiguration : EntityBaseConfiguration<Employee>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Employee> builder)
        {
            builder
                .HasMany(p => p.EmployeeTask)
                .WithOne(p => p.Employee);

            builder
                .HasMany(p => p.EmployeeLevels)
                .WithOne(p => p.Employee);

            builder.ToTable("Employee", "employee");
        }
    }
}
