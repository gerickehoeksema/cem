namespace CEM.DAL.Entities
{
    public class EmployeeLevel : AuditableEntity
    {
        public string Level { get; set; }
        public long EmployeeId { get; set; }

        public Employee Employee { get; set; }
    }
}
