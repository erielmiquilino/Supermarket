using Supermarket.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Domain.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> InsertAsysnc(T Item);

        Task<T> UpdateAsync(T item);

        Task<bool> DeleteAsync(Guid id);

        Task<T> SelectAsync(Guid id);

        Task<IEnumerable<T>> SelectAsync();
    }
}
