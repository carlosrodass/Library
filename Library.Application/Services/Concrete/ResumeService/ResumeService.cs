using AutoMapper;
using CSharpFunctionalExtensions;
using MyLibrary.Application.Contracts.Persistence;
using MyLibrary.Application.Dtos.Resume;
using MyLibrary.Application.Services.Abstract;
using MyLibrary.Application.Services.Abstract.BookService;
using MyLibrary.Domain.Common;
using MyLibrary.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Application.Services.Concrete.ResumeService
{
    internal class ResumeService : IResumeService
    {
        #region Fields
        private readonly IMapper _mapper;
        private readonly IResumeRepository _resumeRepository;
        private readonly IBookRepository _bookRepository;

        #endregion

        #region Builder

        public ResumeService(IMapper mapper, IResumeRepository resumeRepository, IBookRepository bookRepository)
        {
            _mapper = mapper;
            _resumeRepository = resumeRepository;
            _bookRepository = bookRepository;
        }

        #endregion

        #region Public Methods

        public async Task<Result<List<ResumeDto>, Error>> GetAllResumesByBook(long bookId)
        {
            throw new NotImplementedException();
        }

        public async Task<Result<ResumeDto, Error>> GetResumeById(long resumeId)
        {
            throw new NotImplementedException();
        }

        public async Task<Result<ResumeDto, Error>> CreateResumeAndAssignToBookAsync(ResumeDto resumeDto)
        {
            var bookFound = await _bookRepository.GetBookById(resumeDto.BookId.Value);
            if (bookFound == null) { return CustomErrors.Book.NotFound(); }

            Resume resume = new()
            {
                Title = resumeDto.Title,
                Description = resumeDto.Description,
                Content = resumeDto.Content,
                ResumeTypeId = resumeDto.ResumeTypeId,
            };

            await _resumeRepository.CreateAsync(resume);
            await _resumeRepository.SaveChangesAsync();

            bookFound.Resumes.Add(resume);

            _bookRepository.Update(bookFound);
            await _bookRepository.SaveChangesAsync();

            return _mapper.Map<ResumeDto>(resume);
        }

        public async Task<Result<ResumeDto, Error>> UpdateResumeAsync(ResumeDto resumeDto)
        {
            throw new NotImplementedException();
        }



        #endregion

        #region Private Methods

        #endregion

    }
}
