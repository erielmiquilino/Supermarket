using Supermarket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IRepository<UserDto>
    {
        Task<UserDto> FindByLogin(String email);
    }
}
