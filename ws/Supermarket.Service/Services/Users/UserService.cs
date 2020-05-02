using AutoMapper;
using Supermarket.Domain.Dtos.Users;
using Supermarket.Domain.Entities;
using Supermarket.Domain.Interfaces;
using Supermarket.Domain.Interfaces.Services.Users;
using Supermarket.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Supermarket.Service.Services.Users
{
    public class UserService : IUserService
    {
        private IRepository<User> _repository;

        private readonly IMapper _mapper;

        public UserService(IRepository<User> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<UserDto> Get(Guid id)
        {
            var entity = await _repository.SelectAsync(id);

            return _mapper.Map<UserDto>(entity);
        }

        public async Task<IEnumerable<UserDto>> GetAll()
        {
            var listEntity = await _repository.SelectAsync();

            return _mapper.Map<IEnumerable<UserDto>>(listEntity);
        }

        public async Task<UserDtoCreateResult> Post(UserDtoCreate user)
        {
            var userModel = _mapper.Map<UserModel>(user);
            var entity = _mapper.Map<User>(userModel);

            var result = await _repository.InsertAsysnc(entity);

            return _mapper.Map<UserDtoCreateResult>(result);
        }

        public async Task<UserDtoUpdateResult> Put(UserDtoUpdate user)
        {
            var userModel = _mapper.Map<UserModel>(user);
            var entity = _mapper.Map<User>(userModel);

            var result = await _repository.UpdateAsync(entity);

            return _mapper.Map<UserDtoUpdateResult>(result);
        }
    }
}
