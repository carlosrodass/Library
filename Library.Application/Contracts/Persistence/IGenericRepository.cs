﻿
using Microsoft.EntityFrameworkCore.Query;
using MyLibrary.Domain.Common;
using MyLibrary.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Application.Contracts.Persistence
{
    public interface IGenericRepository<T> where T : AggregateRoot
    {
        Task<IReadOnlyList<T>> GetAsync(Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null);
        Task<T> GetByIdAsync(long id, Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null);
        Task<IEnumerable<T>> GetByIdsAsync(IEnumerable<long> ids, Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task SaveChangesAsync();
        Task AddRange(List<T> values);

    }
}
