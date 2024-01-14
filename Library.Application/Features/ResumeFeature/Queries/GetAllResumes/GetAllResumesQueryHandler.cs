using AutoMapper;
using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using MyLibrary.Application.Contracts.Persistence;
using MyLibrary.Application.Dtos.Resume;
using MyLibrary.Domain.Common;
using MyLibrary.Domain.Models;

namespace MyLibrary.Application.Features.ResumeFeature.Queries.GetAllResumes;

public class GetAllResumesQueryHandler : IRequestHandler<GetAllResumesQuery, Result<List<GetAllResumesDto>, Error>>
{

    #region Fields
    private readonly IBookRepository _bookRepository;
    private readonly IMapper _mapper;


    #endregion

    #region Builder

    public GetAllResumesQueryHandler(IBookRepository bookRepository, IMapper mapper)
    {
        _bookRepository = bookRepository;
        _mapper = mapper;
    }

    #endregion

    #region Public methods

    public async Task<Result<List<GetAllResumesDto>, Error>> Handle(GetAllResumesQuery request, CancellationToken cancellationToken)
    {
        var book = await _bookRepository.GetByIdAsync(request.BookId, GetIncludes());
        if (book is null) { return Error.NotFound; }

        var resumes = book.Resumes;
        if (resumes is null) { return new List<GetAllResumesDto>(); }

        return _mapper.Map<List<GetAllResumesDto>>(resumes);
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
