using System.Collections;
using System.Threading.Tasks;
using Supermarket.Domain.Dtos.Carts;
using Supermarket.Domain.Entities;

namespace Supermarket.Domain.Interfaces.Services.Carts
{
    public interface ICartService
    {
        Task<Cart> Post(CartDtoCreate cart);
    }
}
