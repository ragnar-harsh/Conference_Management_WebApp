using Microsoft.AspNetCore.Identity;

namespace backend.Models
{
    public class ApplicationUser : IdentityUser
    {
        public required string firstname { get; set; }
        public required string lastname { get; set; }
        public required string role { get; set; }
    }
}