using Microsoft.EntityFrameworkCore;

namespace miniapp1
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }    
    }
}
