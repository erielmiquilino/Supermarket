using Supermarket.Domain.Dtos;
using System.Threading.Tasks;

namespace Supermarket.Domain.Interfaces.Services.Users
{
    public interface ILoginService
    {
        Task<object> FindByLogin(LoginDto login);
    }
}
