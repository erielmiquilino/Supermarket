using Supermarket.Domain.Entities;
using System.Threading.Tasks;

namespace Supermarket.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> FindByLogin(string email);
    }
}
