using Microsoft.EntityFrameworkCore;
using ShoppingCartAPI.Entities;

namespace ShoppingCartAPI.Context
{
    public class ShoppingCartContext : DbContext
    {
        public ShoppingCartContext(DbContextOptions<ShoppingCartContext> options) : base(options)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().Property(p => p.Price).HasColumnType("decimal(18,4)");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
