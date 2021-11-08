using AutoMapper;
using Supermarket.Domain.Dtos.Products;
using Supermarket.Domain.Entities;
using Supermarket.Domain.Interfaces;
using Supermarket.Domain.Interfaces.Services.Products;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Supermarket.Service.Services.Products
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _repository;
        private readonly IMapper _mapper;

        public ProductService(IRepository<Product> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<Product> Get(Guid id)
        {
            return await _repository.SelectAsync(id);
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _repository.SelectAsync();
        }

        public async Task<Product> Post(ProductDtoCreate product)
        {
            var entity = _mapper.Map<Product>(product);

            return await _repository.InsertAsync(entity);
        }

        public async Task<Product> Put(Product product)
        {
            return await _repository.UpdateAsync(product);
        }
    }
}
