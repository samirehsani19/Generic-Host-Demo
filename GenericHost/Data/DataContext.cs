using Microsoft.EntityFrameworkCore;

namespace GenericHost
{
    class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Actor> Actor { get; set; }
        public DbSet<Movie> Movie { get; set; }

    }
}
