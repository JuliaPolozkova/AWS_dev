using Microsoft.EntityFrameworkCore;

namespace OnlineShop.Models
{
    public class RDSContext : DbContext
    {
        public RDSContext(DbContextOptions<RDSContext> options)
       : base(options)
        {
        }

        public DbSet<ShoppingCart> ShoppingCarts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShoppingCart>()
                .Property(b => b.Id)
                .IsRequired();
        }
    }
}
