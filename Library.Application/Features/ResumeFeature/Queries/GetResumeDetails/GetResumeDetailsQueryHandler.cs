using AutoMapper;
using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using MyLibrary.Application.Contracts.Persistence;
using MyLibrary.Application.Dtos.Resume;
using MyLibrary.Domain.Common;
using MyLibrary.Domain.Models;

namespace MyLibrary.Application.Features.ResumeFeature.Queries.GetResumeDetails
{
    public class GetResumeDetailsQueryHandler : IRequestHandler<GetResumeDetailsQuery, Result<GetResumeDetailsDto, Error>>
    {
        #region Fields
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        #endregion

        #region Builder
        public GetResumeDetailsQueryHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        #endregion

        #region Public methods

        public async Task<Result<GetResumeDetailsDto, Error>> Handle(GetResumeDetailsQuery request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetByIdAsync(request.BookId, GetIncludes());
            if (book is null) { return Error.NotFound; }

            var resumes = book.Resumes;
            if (resumes is null) { return Error.NotFound; }

            var resumeFound = resumes.FirstOrDefault(x => x.Id == request.Id);
            if (resumeFound is null) { return Error.NotFound; }

            return _mapper.Map<GetResumeDetailsDto>(resumeFound);
        }

        #endregion


        #region Includes
        private Func<IQueryable<Book>, IIncludableQueryable<Book, object>> GetIncludes()
        {
            return includes => includes
                .Include(b => b.Resumes);
        }


        #endregion
    }
}
