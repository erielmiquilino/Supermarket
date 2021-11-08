using Supermarket.Domain.Dtos.Carts;
using Supermarket.Domain.Entities;
using Supermarket.Domain.Interfaces.Services.Carts;
using System;
using System.Threading.Tasks;
using AutoMapper;
using Supermarket.Domain.Interfaces;

namespace Supermarket.Service.Services.Carts
{
    public class CartService : ICartService
    {
        private readonly IRepository<Cart> _repository;
        private readonly IMapper _mapper;

        public CartService(IRepository<Cart> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Cart> Post(CartDtoCreate cart)
        {
            var entity = _mapper.Map<Cart>(cart);

            return await _repository.InsertAsync(entity);
        }
    }
}
