using Microsoft.EntityFrameworkCore;
using Task3.Repositories.Entities;

namespace Task3.Repositories
{
    /// <summary>
    /// Represents the Task3DbContext Class.
    /// </summary>
    public class Task3DbContext : DbContext
    {
        public Task3DbContext(DbContextOptions<Task3DbContext> options) : base(options)
        { }

        public DbSet<Customer> Customer { get; set; }
    }
}
