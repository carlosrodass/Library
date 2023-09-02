using Library.Application.Contracts.Persistence;
using Library.Domain;
using Library.Persistence.DataBaseContext;


namespace Library.Persistence.Repositories
{
    public class LibraryBookRepository : GenericRepository<LibraryBook>, ILibraryBookRepository
    {
        public LibraryBookRepository(LibraryDatabaseContext context) : base(context) { }

    }
}
