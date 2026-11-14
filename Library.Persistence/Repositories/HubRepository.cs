using Microsoft.EntityFrameworkCore;
using MyLibrary.Application.Contracts.Persistence;
using MyLibrary.Application.Dtos;
using MyLibrary.Domain.Models;
using MyLibrary.Persistence.DataBaseContext;


namespace MyLibrary.Persistence.Repositories
{
    public class HubRepository : GenericRepository<Hub>, IHubRepository
    {
        public HubRepository(LibraryDatabaseContext context) : base(context)
        {
        }

        public async Task<List<HubDto>> GetHubsWithDetails(string userId)
        {
            var query = from hub in _context.Hubs
                        join status in _context.Status on hub.StatusId equals status.Id
                        select new HubDto
                        {
                            HubId = hub.HubId,
                            Name = hub.Name,
                            Description = hub.Description,
                            StatusId = status.Id,
                            //NumOfBooks = hub.BookHubs.Count()
                            NumOfBooks = 0
                        };


            return await query.ToListAsync();
        }

        public async Task<Hub> GetHubWithDetails(long hubId, string userId)
        {
            return await (from h in _context.Hubs
                          join status in _context.Status on h.StatusId equals status.Id
                          where h.HubId == hubId
                          select new Hub
                          {
                              HubId = h.HubId,
                              Name = h.Name,
                              Description = h.Description,
                              StatusId = status.Id
                          }).FirstOrDefaultAsync();


        }

        public async Task<List<BookHub>> GetBookHubByHubId(long hubId)
        {
            var query = _context.BookHubs
              .Where(bh => bh.HubId == hubId)
              .Include(bh => bh.Book)
              .ToList();

            return query;
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