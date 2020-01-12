using Supermarket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Domain.Interfaces.Services.Users
{
    public interface IUserService
    {
        Task<UserDto> Get(Guid id);

        Task<IEnumerable<UserDto>> GetAll();

        Task<UserDto> Post(UserDto user);

        Task<UserDto> Put(UserDto user);

        Task<bool> Delete(Guid id);
    }
}
