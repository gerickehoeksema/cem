using System;

namespace CEM.DAL.Entities
{
    public abstract class AuditableEntity
    {
        public long Id { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public long? CreatedBy { get; set; }
        public long? UpdatedBy { get; set; }
    }
}
