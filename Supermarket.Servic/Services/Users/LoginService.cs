using Supermarket.Domain.Entities;
using Supermarket.Domain.Interfaces.Repositories;
using Supermarket.Domain.Interfaces.Services.Users;
using System.Threading.Tasks;

namespace Supermarket.Service.Services.Users
{
    public class LoginService : ILoginService
    {
        IUserRepository _userRepository;

        public LoginService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<object> FindByLogin(UserDto user)
        {
            if (user != null && !string.IsNullOrEmpty(user.Email))
                return await _userRepository.FindByLogin(user.Email);
            else
                return null;
        }
    }
}
