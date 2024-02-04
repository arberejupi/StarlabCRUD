using Microsoft.EntityFrameworkCore;
using StarlabsCRUD.Model;

namespace StarlabsCRUD.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Person> Person { get; set; }
    }
}
