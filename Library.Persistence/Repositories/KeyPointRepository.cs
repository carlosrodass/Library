using Microsoft.EntityFrameworkCore;
using MyLibrary.Application.Contracts.Persistence;
using MyLibrary.Domain.Models;
using MyLibrary.Persistence.DataBaseContext;

namespace MyLibrary.Persistence.Repositories
{
    public class KeyPointRepository : GenericRepository<KeyPoint>, IKeyPointRepository
    {

        public KeyPointRepository(LibraryDatabaseContext context) : base(context)
        {
        }

        public async Task<KeyPoint> GetKeyPointWithDetails(long id)
        {
            var keyPoint = await _context.KeyPoints
                 .FirstOrDefaultAsync(q => q.KeyPointId == id);

            return keyPoint;
        }
    }


}

