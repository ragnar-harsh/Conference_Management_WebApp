using backend.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace backend.Data 
{
    public class ContextClass : IdentityDbContext<ApplicationUser>
    {
        public ContextClass(DbContextOptions<ContextClass> options) : base(options)
        {
            
        }

        public DbSet<Meetings> Meetings { get; set; }
    }

}