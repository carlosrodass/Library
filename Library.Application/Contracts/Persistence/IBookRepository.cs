
using MyLibrary.Domain.Models;

namespace MyLibrary.Application.Contracts.Persistence
{
    public interface IBookRepository : IGenericRepository<Book>
    {
        Task<List<Book>> GetBooksWithDetails();
        Task<Book> GetBookWithDetails(long id);
    }


}
