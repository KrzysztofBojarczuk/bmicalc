using Microsoft.EntityFrameworkCore;

namespace bmiwebApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Body> Bodies { get; set; }
    }
}
