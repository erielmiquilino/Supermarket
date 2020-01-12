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
        private IRepository<UserDto> _repository;

        public UserService(IRepository<UserDto> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<UserDto> Get(Guid id)
        {
            return await _repository.SelectAsync(id);
        }

        public async Task<IEnumerable<UserDto>> GetAll()
        {
            return await _repository.SelectAsync();
        }

        public async Task<UserDto> Post(UserDto user)
        {
            return await _repository.InsertAsysnc(user);
        }

        public async Task<UserDto> Put(UserDto user)
        {
            return await _repository.UpdateAsync(user);
        }
    }
}
