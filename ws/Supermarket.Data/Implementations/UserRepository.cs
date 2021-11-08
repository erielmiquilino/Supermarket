using Microsoft.EntityFrameworkCore;
using Supermarket.Data.Context;
using Supermarket.Data.Repository;
using Supermarket.Domain.Entities;
using Supermarket.Domain.Interfaces.Repositories;
using System.Threading.Tasks;
using Supermarket.Domain.Dtos;

namespace Supermarket.Data.Implementations
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly DbSet<User> _database;

        public UserRepository(MyContext context) : base(context)
        {
            _database = context.Set<User>();
        }

        public async Task<User> FindByLogin(LoginDto loginDto)
        {
            return await _database
                .FirstOrDefaultAsync(user => user.Email.Equals(loginDto.Email) && user.Password.Equals(loginDto.Password));
        }
    }
}
