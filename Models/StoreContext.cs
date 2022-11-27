using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace StoreApi.Models
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; } = null!;
    }
}