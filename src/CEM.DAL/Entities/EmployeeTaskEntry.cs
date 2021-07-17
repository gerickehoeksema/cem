using System;

namespace CEM.DAL.Entities
{
    public class EmployeeTaskEntry : AuditableEntity
    {
        public TimeSpan Time { get; set; }
        public string Comment { get; set; }
        public long TaskId { get; set; }

        public Task Task { get; set; }
    }
}
