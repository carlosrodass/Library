using MyLibrary.Application.Dtos;
using MyLibrary.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Application.Contracts.Persistence
{
    public interface IHubRepository : IGenericRepository<Hub>
    {
        Task<List<HubDto>> GetHubsWithDetails(string userId);
        Task<Hub> GetHubWithDetails(long hubId, string userId);
        Task<Status> GetHubStatusById(long statusId);
        Task<bool> AddBookToHubAsync(BookHub bookHub);
        Task<List<BookHub>> GetBookHubByHubId(long hubId);
    }
}
