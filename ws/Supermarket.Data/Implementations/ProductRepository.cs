using Microsoft.EntityFrameworkCore;
using Supermarket.Data.Context;
using Supermarket.Data.Repository;
using Supermarket.Domain.Entities;
using Supermarket.Domain.Interfaces.Repositories;

namespace Supermarket.Data.Implementations
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        private readonly DbSet<Product> _database;

        public ProductRepository(MyContext context) : base(context)
        {
            _database = context.Set<Product>();
        }
    }
}
