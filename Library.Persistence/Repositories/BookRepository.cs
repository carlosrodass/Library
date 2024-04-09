
using Microsoft.EntityFrameworkCore;
using MyLibrary.Application.Contracts.Persistence;
using MyLibrary.Domain.Models;
using MyLibrary.Persistence.DataBaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Persistence.Repositories
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        public BookRepository(LibraryDatabaseContext context) : base(context)
        {

        }

        public async Task<List<Book>> GetBooksByHubId(long hubId)
        {
            var books = await _context.Books
               .Include(q => q.Resume)
               .ThenInclude(q => q.KeyPoints)
               .Include(q => q.BookHubs)
               .Where(e => !e.IsDeleted && e.BookHubs.Any(x => x.HubId == hubId))
               .ToListAsync();

            return books;
        }
        public async Task<Book> GetBookWithDetails(long id)
        {
            var book = await _context.Books
               .Include(q => q.Resume)
                    .ThenInclude(q => q.KeyPoints)
                    .Where(e => !e.IsDeleted)
               .FirstOrDefaultAsync(q => q.BookId == id);

            return book;
        }

        public async Task<Book> GetBookById(long id)
        {
            var book = await _context.Books
               .Include(q => q.Resume)
                    .ThenInclude(q => q.KeyPoints)
                    .Where(e => !e.IsDeleted)
            .FirstOrDefaultAsync(q => q.BookId == id);

            return book;
        }


    }
}
