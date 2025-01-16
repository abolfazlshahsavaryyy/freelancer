using Microsoft.AspNetCore.Identity;

namespace Freelancer.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string? FirstName {  get; set; }
        public string? Birthday {  get; set; }
    }
}
