using Supermarket.Domain.Entities;
using Supermarket.Domain.Interfaces;
using Supermarket.Domain.Interfaces.Services.Users;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Supermarket.Service.Services.Users
{
    public class UserService : IUserService
    {
        private IRepository<User> _repository;

        public UserService(IRepository<User> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<User> Get(Guid id)
        {
            return await _repository.SelectAsync(id);
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _repository.SelectAsync();
        }

        public async Task<User> Post(User user)
        {
            return await _repository.InsertAsysnc(user);
        }

        public async Task<User> Put(User user)
        {
            return await _repository.UpdateAsync(user);
        }
    }
}
