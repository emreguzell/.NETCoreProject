using Microsoft.EntityFrameworkCore;
using Week2Homework.DataModel;

namespace Week2Homework.DBOperations
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options)
        {

        }
        public DbSet<Customer> Customer { get; set; }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
