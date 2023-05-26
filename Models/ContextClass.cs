using Microsoft.EntityFrameworkCore;

namespace LoginRegistration.Models
{
    public class ContextClass: DbContext
    {
        public ContextClass(DbContextOptions options) : base(options) { 
        
        }
        public DbSet<User> Users { get; set; }  
    }
}
