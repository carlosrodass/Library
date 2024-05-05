using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Query;
using MyLibrary.Application.Contracts.Persistence;
using MyLibrary.Domain.Common;
using MyLibrary.Persistence.DataBaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Persistence.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly LibraryDatabaseContext _context;

    public GenericRepository(LibraryDatabaseContext context)
    {
        this._context = context;
    }

    //public async Task<IReadOnlyList<T>> GetAsync(Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null)
    //{
    //    return await _context.Set<T>().AsNoTracking().ToListAsync();
    //}

    //public async Task<T> GetByIdAsync(long id, Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null)
    //{
    //    return await _context.Set<T>()
    //         .AsNoTracking()
    //         .FirstOrDefaultAsync(q => q.Id == id);
    //}

    //public async Task<IEnumerable<T>> GetByIdsAsync(IEnumerable<long> ids, Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null)
    //{
    //    var query = GetQuery(includes);
    //    return await query.Where(entity => ids.Contains(entity.Id)).ToListAsync();
    //}


    public async Task<IReadOnlyList<T>> GetAsync()
    {
        return await _context.Set<T>().AsNoTracking().ToListAsync();
    }

    public async Task<T> GetByIdAsync(long id)
    {
        return await _context.Set<T>().FindAsync(id);
        //.AsNoTracking()
    }

    public async Task CreateAsync(T entity)
    {
        await _context.AddAsync(entity);
    }

    public void Update(T entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
    }

    public void Delete(T entity)
    {
        _context.Remove(entity);
    }


    public async Task AddRange(List<T> entities)
    {
        await _context.AddRangeAsync(entities);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    //public virtual IQueryable<T> GetQuery(Func<IQueryable<T>, IIncludableQueryable<T, object>> includes)
    //{
    //    IQueryable<T> query = Entities.AsNoTracking();

    //    if (includes != null)
    //    {
    //        query = includes(query);
    //    }
    //    return query;
    //}

    //static void DisplayStates(IEnumerable<EntityEntry> entries)
    //{
    //    foreach (var entry in entries)
    //    {
    //        Console.WriteLine($"Entity: {entry.Entity.GetType().Name}, State: {entry.State.ToString()}");
    //    }
    //}
}
