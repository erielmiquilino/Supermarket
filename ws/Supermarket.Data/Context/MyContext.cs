using Microsoft.EntityFrameworkCore;
using Supermarket.Data.MappingConfiguration;
using Supermarket.Domain.Entities;

namespace Supermarket.Data.Context
{
    public class MyContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public MyContext(DbContextOptions<MyContext> options) : base (options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>(new ProductConfiguration().Configure);
            modelBuilder.Entity<User>(new UserConfiguration().Configure);
            modelBuilder.Entity<Cart>(new CartConfiguration().Configure);
            modelBuilder.Entity<CartItem>(new CartItemConfiguration().Configure);
        }
    }
}
