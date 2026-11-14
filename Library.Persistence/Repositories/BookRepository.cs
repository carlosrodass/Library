
using Microsoft.EntityFrameworkCore;
using MyLibrary.Application.Contracts.Persistence;
using MyLibrary.Domain.Models;
using MyLibrary.Persistence.DataBaseContext;


namespace MyLibrary.Persistence.Repositories;

public class BookRepository : GenericRepository<Book>, IBookRepository
{
    public BookRepository(LibraryDatabaseContext context) : base(context)
    {

    }

    public async Task<List<Book>> GetBooksByHubId(long hubId)
    {
        var books = await (
          from b in _context.Books
          join bh in _context.BookHubs on b.BookId equals bh.BookId
          where !b.IsDeleted && bh.HubId == hubId
          select b).Distinct().ToListAsync();



        return books;
    }
    public async Task<Book> GetBookWithDetails(long id)
    {
        var book = await _context.Books
           .Include(q => q.Resumes)
                .ThenInclude(q => q.KeyPoints)
                .Where(e => !e.IsDeleted)
           .FirstOrDefaultAsync(q => q.BookId == id);

        return book;
    }

    public async Task<bool> CheckBookExistById(long id)
    {
        var IsbookInDb = await _context.Books.Include(b => b.Resumes).Where(e => !e.IsDeleted)
        .AnyAsync(q => q.BookId == id);

        return IsbookInDb;
    }


}
