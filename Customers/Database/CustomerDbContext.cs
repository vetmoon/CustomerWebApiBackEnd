using Customers.Models;
using Microsoft.EntityFrameworkCore;

namespace Customers.Database
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
    }
}
