using Microsoft.AspNetCore.Identity;

namespace RoleBasedAuthorization.Models.Data
{
    public class ApplicationUser :IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? ProfilePicture { get; set; }
    }
}
