using Library.Application.Contracts.Persistence;
using Library.Domain;
using Library.Domain.Common;
using Library.Persistence.DataBaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected readonly LibraryDatabaseContext _context;

        public GenericRepository(LibraryDatabaseContext context)
        {
            this._context = context;
        }

        public async Task CreateAsync(T entity)
        {
            await _context.AddAsync(entity);

        }


        public async Task DeleteAsync(T entity)
        {
            //_context.Entry(entity).State = EntityState.Modified;
            //entity.IsDeleted = true;
            //entity.DeletedAt = DateTime.UtcNow;

            _context.Remove(entity);

        }

        public async Task<IReadOnlyList<T>> GetAsync()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();

        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().
                AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(T entity)
        {
            //_context.Update(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }


        public async Task AddRange(List<T> values)
        {
            await _context.AddRangeAsync(values);
        }
    }
}
