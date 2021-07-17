using System;
using System.Collections.Generic;

namespace CEM.DAL.Entities
{
    public class EmployeeTask: AuditableEntity
    {
        public EmployeeTask()
        {
            EmployeeTaskEntries = new List<EmployeeTaskEntry>();
        }

        public DateTime StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
        public bool IsComplete { get; set; }
        public long EmployeeId { get; set; }

        public Employee Employee { get; set; }

        public IList<EmployeeTaskEntry> EmployeeTaskEntries { get; }
    }
}
