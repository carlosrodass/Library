
using MyLibrary.Application.Contracts.Persistence;
using MyLibrary.Domain.Models;
using MyLibrary.Persistence.DataBaseContext;

namespace MyLibrary.Persistence.Repositories
{
    public class LibraryBookRepository : GenericRepository<LibraryBook>, ILibraryBookRepository
    {
        public LibraryBookRepository(LibraryDatabaseContext context) : base(context) { }

    }
}
