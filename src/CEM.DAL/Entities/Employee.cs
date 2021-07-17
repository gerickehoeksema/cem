using System.Collections;
using System.Collections.Generic;

namespace CEM.DAL.Entities
{
    public class Employee : AuditableEntity
    {
        public Employee()
        {
            EmployeeTask = new List<EmployeeTask>();
            EmployeeLevels = new List<EmployeeLevel>();
        }

        public long UserId { get; set; }
        public long? ImageId { get; set; }

        public Image ProfileImage { get; set; }

        public IList<EmployeeTask> EmployeeTask { get; }
        public IList<EmployeeLevel> EmployeeLevels { get; }
    }
}
