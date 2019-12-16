using Microsoft.EntityFrameworkCore;
using Supermarket.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Supermarket.Data.Context
{
    public class MyContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Cart> Carts { get; set; }

        public DbSet<CartItem> CartItems { get; set; }

        public MyContext(DbContextOptions<MyContext> options) : base (options)
        {

        }
    }
}
