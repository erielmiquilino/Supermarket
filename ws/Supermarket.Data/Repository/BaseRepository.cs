using Microsoft.EntityFrameworkCore;
using Supermarket.Data.Context;
using Supermarket.Domain.Entities.Base;
using Supermarket.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Supermarket.Data.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly MyContext _context;

        private readonly DbSet<T> _dataSet;

        public BaseRepository(MyContext context)
        {
            _context = context;
            _dataSet = _context.Set<T>();
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var result = await _dataSet.SingleOrDefaultAsync(p => p.Id.Equals(id));

            if (result == null)
                return false;

            _dataSet.Remove(result);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistAsync(Guid id)
        {
            return await _dataSet.AnyAsync(p => p.Id.Equals(id));
        }

        public async Task<T> InsertAsync(T item)
        {
            if (item.Id == Guid.Empty)
                item.Id = Guid.NewGuid();

            item.InsertDate = DateTime.UtcNow;
            _dataSet.Add(item);

            await _context.SaveChangesAsync();

            return item;
        }

        public async Task<T> SelectAsync(Guid id)
        {
            return await _dataSet.SingleOrDefaultAsync(p => p.Id.Equals(id));
        }

        public async Task<IEnumerable<T>> SelectAsync()
        {
            return await _dataSet.ToListAsync();
        }

        public async Task<T> UpdateAsync(T item)
        {
            var result = await _dataSet.SingleOrDefaultAsync(p => p.Id.Equals(item.Id));

            if (result == null)
                return null;

            item.InsertDate = result.InsertDate;

            _context.Entry(result).CurrentValues.SetValues(item);
            await _context.SaveChangesAsync();

            return item;
        }
    }
}
