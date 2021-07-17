using System.Collections.Generic;

namespace CEM.DAL.Entities
{
    public class Task : AuditableEntity
    {
        public Task()
        {
            EmployeeTaskEntries = new List<EmployeeTaskEntry>();
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public double Duration { get; set; }

        public IList<EmployeeTaskEntry> EmployeeTaskEntries { get; }
    }
}
