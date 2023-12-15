using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using MyLibrary.Application.Contracts.Persistence;
using MyLibrary.Domain.Common;
using MyLibrary.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : AggregateRoot
    {
        protected readonly DbContext _context;
        protected DbSet<T> Entities => _context.Set<T>();

        public GenericRepository(DbContext context)
        {
            this._context = context;
        }

        public async Task CreateAsync(T entity)
        {
            await _context.AddAsync(entity);
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Remove(entity);
        }

        public async Task<IReadOnlyList<T>> GetAsync(Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null)
        {
            var query = GetQuery(includes);
            return await query.ToListAsync();
        }

        public async Task<T> GetByIdAsync(long id, Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null)
        {
            var query = GetQuery(includes);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> GetByIdsAsync(IEnumerable<long> ids, Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null)
        {
            var query = GetQuery(includes);

            return await query.Where(entity => ids.Contains(entity.Id)).ToListAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public async Task AddRange(List<T> values)
        {
            await _context.AddRangeAsync(values);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }



        public virtual IQueryable<T> GetQuery(Func<IQueryable<T>, IIncludableQueryable<T, object>> includes)
        {
            IQueryable<T> query = Entities.AsNoTracking();

            if (includes != null)
            {
                query = includes(query);
            }
            return query;
        }
    }
}
