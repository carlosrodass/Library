using MyLibrary.Domain.Models;

namespace MyLibrary.Application.Contracts.Persistence
{
    public interface IKeyPointRepository : IGenericRepository<KeyPoint>
    {
        Task<KeyPoint> GetKeyPointWithDetails(long id);
    }
}
