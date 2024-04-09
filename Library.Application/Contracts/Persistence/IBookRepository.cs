
using MyLibrary.Domain.Models;

namespace MyLibrary.Application.Contracts.Persistence
{
    public interface IBookRepository : IGenericRepository<Book>
    {
        Task<List<Book>> GetBooksByHubId(long hubId);
        Task<Book> GetBookWithDetails(long id);
        Task<Book> GetBookById(long id);
    }


}
