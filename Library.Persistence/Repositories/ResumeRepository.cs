using Library.Application.Contracts.Persistence;
using Library.Domain;
using Library.Persistence.DataBaseContext;


namespace Library.Persistence.Repositories
{
    public class ResumeRepository : GenericRepository<Resume>, IResumeRepository
    {
        public ResumeRepository(LibraryDatabaseContext context) : base(context) { }
    }
}
