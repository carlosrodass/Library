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
            var bookFound = await _bookRepository.CheckBookExistById(resumeDto.BookId);
            if (!bookFound) { return CustomErrors.Book.NotFound(); }

            Resume resume = FillResumeEntityByDto(resumeDto);

            await _resumeRepository.CreateAsync(resume);
            await _resumeRepository.SaveChangesAsync();

            return ReturnMappedObjectToDto(resume);
        }



        public async Task<Result<ResumeDto, Error>> UpdateResumeAsync(ResumeDto resumeDto)
        {
            throw new NotImplementedException();
        }



        #endregion

        #region Private Methods
        private Result<ResumeDto, Error> ReturnMappedObjectToDto(Resume resume)
        {
            return new ResumeDto
            {
                ResumeId = resume.ResumeId,
                Title = resume.Title,
                Description = resume.Description,
                Content = resume.Content,
                ResumeTypeId = resume.ResumeTypeId,
                BookId = resume.BookId
            };
        }

        private Resume FillResumeEntityByDto(ResumeDto resumeDto)
        {
            return new Resume()
            {
                Title = resumeDto.Title,
                Description = resumeDto.Description,
                Content = resumeDto.Content,
                ResumeTypeId = resumeDto.ResumeTypeId,
                BookId = resumeDto.BookId
            };
        }

        #endregion

    }
}
