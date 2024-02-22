using Microsoft.AspNetCore.Identity;

namespace FutureCloudContactManager.Models
{
    public class User:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NIN { get; set; }
        public virtual ICollection<Contact>? Contacts { get; set;}
        
    }
}
