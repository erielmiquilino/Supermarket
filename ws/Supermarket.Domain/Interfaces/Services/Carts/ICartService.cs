using Supermarket.Domain.Dtos.Carts;
using Supermarket.Domain.Entities;
using System.Threading.Tasks;

namespace Supermarket.Domain.Interfaces.Services.Carts
{
    public interface ICartService
    {
        Task<Cart> Post(CartDtoCreate cart);
    }
}
