using Supermarket.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Domain.Interfaces.Services.Products
{
    public interface IProductService
    {
        Task<Product> Get(Guid id);

        Task<IEnumerable<Product>> GetAll();

        Task<Product> Post(Product product);

        Task<Product> Put(Product product);

        Task<bool> Delete(Guid id);
    }
}
