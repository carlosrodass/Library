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
    public class HubRepository : GenericRepository<Hub>, IHubRepository
    {
        public HubRepository(LibraryDatabaseContext context) : base(context)
        {

        }

        public async Task<List<Hub>> GetHubsWithDetails(string userId)
        {
            return await _context.Hubs
                .Where(e => !e.IsDeleted)
                .Include(x => x.Status)
                .ToListAsync();
        }

        public async Task<Hub> GetHubWithDetails(long hubId, string userId)
        {
            return await _context.Hubs
            .Include(x => x.Books).ThenInclude(b => b.Resumes)
            .Include(x => x.Status)
            .FirstOrDefaultAsync(q => q.HubId == hubId && !q.IsDeleted);

        }

        public async Task<Status> GetHubStatusById(long statusId)
        {
            return await _context.Status.FirstOrDefaultAsync(x => x.Id == statusId);
        }

    }
}
