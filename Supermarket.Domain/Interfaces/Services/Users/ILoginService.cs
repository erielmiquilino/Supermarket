using Supermarket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Domain.Interfaces.Services.Users
{
    public interface ILoginService
    {
        Task<object> FindByLogin(User user);
    }
}
