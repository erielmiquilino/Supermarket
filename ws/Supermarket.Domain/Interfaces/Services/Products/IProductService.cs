using Supermarket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Supermarket.Domain.Dtos.Products;

namespace Supermarket.Domain.Interfaces.Services.Products
{
    public interface IProductService
    {
        Task<Product> Get(Guid id);

        Task<IEnumerable<Product>> GetAll();

        Task<Product> Post(ProductDtoCreate product);

        Task<Product> Put(Product product);

        Task<bool> Delete(Guid id);
    }
}
