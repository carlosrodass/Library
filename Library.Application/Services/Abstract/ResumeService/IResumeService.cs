using CSharpFunctionalExtensions;
using MyLibrary.Application.Dtos.Resume;
using MyLibrary.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Application.Services.Abstract
{
    public interface IResumeService
    {
        Task<Result<List<ResumeDto>, Error>> GetAllResumesByBook(long bookId);
        Task<Result<ResumeDto, Error>> GetResumeById(long resumeId);
        Task<Result<ResumeDto, Error>> CreateResumeAndAssignToBookAsync(ResumeDto resumeDto);
        Task<Result<ResumeDto, Error>> UpdateResumeAsync(ResumeDto resumeDto);
    }
}
