using Core.Entitites;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)     // Constructor to pass in options with StoreContext
        {

        }

        public DbSet<Product> Products { get; set; }    // property for Product entity, name of the table when code it generated.
    }
}