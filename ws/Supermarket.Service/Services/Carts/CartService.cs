using AutoMapper;
using Supermarket.Domain.Dtos.Carts;
using Supermarket.Domain.Entities;
using Supermarket.Domain.Interfaces;
using Supermarket.Domain.Interfaces.Services.Carts;
using System.Threading.Tasks;

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
