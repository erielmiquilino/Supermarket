using Supermarket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Supermarket.Domain.Interfaces.Services.Users
{
    public interface IUserService
    {
        Task<User> Get(Guid id);

        Task<IEnumerable<User>> GetAll();

        Task<User> Post(User user);

        Task<User> Put(User user);

        Task<bool> Delete(Guid id);
    }
}
