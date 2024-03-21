using InventoryBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryBackend.Context
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) { 
            
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
