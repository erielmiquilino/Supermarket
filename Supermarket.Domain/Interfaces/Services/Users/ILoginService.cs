using Supermarket.Domain.Entities;
using System.Threading.Tasks;

namespace Supermarket.Domain.Interfaces.Services.Users
{
    public interface ILoginService
    {
        Task<object> FindByLogin(UserDto user);
    }
}
