using Microsoft.EntityFrameworkCore;
using MyLibrary.Application.Contracts.Persistence;
using MyLibrary.Domain.Models;
using MyLibrary.Persistence.DataBaseContext;


namespace MyLibrary.Persistence.Repositories
{
    public class HubRepository : GenericRepository<Hub>, IHubRepository
    {
        public HubRepository(LibraryDatabaseContext context) : base(context)
        {
        }

        public async Task<List<Hub>> GetHubsWithDetails(string userId)
        {
            var query = from hub in _context.Hubs
                        join status in _context.Status on hub.StatusId equals status.Id
                        select new Hub
                        {
                            HubId = hub.HubId,
                            Name = hub.Name,
                            Description = hub.Description,
                            Image = hub.Image,
                            StatusId = status.Id,
                            Status = status
                        };


            return await query.ToListAsync();
        }

        public Hub GetHubWithDetails(long hubId, string userId)
        {
            var result = (from h in _context.Hubs
                          join status in _context.Status on h.StatusId equals status.Id
                          where h.HubId == hubId
                          select new Hub
                          {
                              HubId = h.HubId,
                              Name = h.Name,
                              Description = h.Description,
                              StatusId = status.Id
                          }).FirstOrDefault();

            return result;
        }

        public async Task<Status> GetHubStatusById(long statusId)
        {
            return await _context.Status.FirstOrDefaultAsync(x => x.Id == statusId);
        }

        public async Task<bool> AddBookToHubAsync(BookHub bookHub)
        {
            try
            {
                _context.Set<BookHub>().Add(bookHub);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}