using CEM.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CEM.DAL.Configuration
{
    public class TaskConfiguration : EntityBaseConfiguration<Task>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Task> builder)
        {
            builder.Property(p => p.Title).HasMaxLength(256).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(int.MaxValue).IsRequired();

            builder
                .HasMany(p => p.EmployeeTaskEntries)
                .WithOne(p => p.Task);

            builder.ToTable("Task", "task");
        }
    }
}
