using Supermarket.Domain.Entities;
using System.Threading.Tasks;
using Supermarket.Domain.Dtos;

namespace Supermarket.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> FindByLogin(LoginDto loginDto);
    }
}
