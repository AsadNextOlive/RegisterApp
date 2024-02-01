using Microsoft.EntityFrameworkCore;
using RegisterAPI.Model;

namespace RegisterAPI.Data
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<Register> Register { get; set; }
        //private readonly IConfiguration _configuration;
        //public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration) : base(options)
        //{
        //    _configuration = configuration;
        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //{
        //    options.UseSqlServer(_configuration.GetConnectionString("SQLServerConnection"));
        //}

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
