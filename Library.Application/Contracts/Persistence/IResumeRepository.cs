
using Microsoft.EntityFrameworkCore.Query;
using MyLibrary.Domain.Models;


namespace MyLibrary.Application.Contracts.Persistence
{
    public interface IResumeRepository : IGenericRepository<Resume>
    {
        Task<Resume> GetResumeWithDetails(long id);
    }
}
