using Microsoft.AspNetCore.Identity;

namespace CEM.DAL.Entities
{
    public class AccountUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; }
    }
}
