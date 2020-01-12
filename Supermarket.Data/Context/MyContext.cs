using Microsoft.EntityFrameworkCore;
using Supermarket.Data.MappingConfiguration;
using Supermarket.Domain.Entities;
using Supermarket.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

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
            modelBuilder.Entity<UserDto>(new UserConfiguration().Configure);
        }
    }
}
