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
            //return await _context.Hubs
            //.Where(e => (e.UserId == userId && e.UserId != null) && !e.IsDeleted)
            //.ToListAsync();

            return await _context.Hubs
                .Where(e => !e.IsDeleted)
                .ToListAsync();
        }

        public async Task<Hub> GetHubWithDetails(long hubId, string userId)
        {
            //return await _context.Hubs
            //            .Include(x => x.Books)
            //            .Where(e => !e.IsDeleted && e.UserId == userId)
            //            .FirstOrDefaultAsync(q => q.HubId == hubId);

            return await _context.Hubs
            .Include(x => x.Books)
            .Where(e => !e.IsDeleted)
            .FirstOrDefaultAsync(q => q.HubId == hubId);

        }
    }
}
