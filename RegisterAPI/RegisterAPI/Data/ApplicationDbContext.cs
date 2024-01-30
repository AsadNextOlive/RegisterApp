using Microsoft.EntityFrameworkCore;
using RegisterAPI.Model;

namespace RegisterAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Register> Register { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        
        }
    }
}
