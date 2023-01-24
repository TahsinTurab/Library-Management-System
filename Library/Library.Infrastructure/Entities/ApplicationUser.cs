using Microsoft.AspNetCore.Identity;

namespace Library.Infrastructure.Entities
{
    public class ApplicationUser : IdentityUser<Guid>
    {  
        public string StudentId { get; set; }
    }
}
