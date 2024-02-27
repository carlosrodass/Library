using Microsoft.EntityFrameworkCore;
using MyLibrary.Application.Contracts.Persistence;
using MyLibrary.Domain.Models;
using MyLibrary.Persistence.DataBaseContext;

namespace MyLibrary.Persistence.Repositories
{
    public class ResumeRepository : GenericRepository<Resume>, IResumeRepository
    {

        public ResumeRepository(LibraryDatabaseContext context) : base(context)
        {

        }

        public async Task<Resume> GetResumeWithDetails(long id)
        {
            var resume = await _context.Resumes
               .Include(q => q.KeyPoints)
               .FirstOrDefaultAsync(q => q.ResumeId == id);

            return resume;
        }
    }


}

