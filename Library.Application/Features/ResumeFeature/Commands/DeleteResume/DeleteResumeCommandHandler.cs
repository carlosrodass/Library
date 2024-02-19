using AutoMapper;
using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using MyLibrary.Application.Contracts.Persistence;
using MyLibrary.Domain.Common;
using MyLibrary.Domain.Models;

namespace MyLibrary.Application.Features.ResumeFeature.Commands.DeleteResume;

public class DeleteResumeCommandHandler : IRequestHandler<DeleteResumeCommand, Result<Unit, Error>>
{
    #region Fields

    private readonly IBookRepository _bookRepository;
    private readonly IMapper _mapper;

    #endregion

    #region Builder

    public DeleteResumeCommandHandler(IBookRepository bookRepository, IMapper mapper)
    {
        _bookRepository = bookRepository;
        _mapper = mapper;
    }

    #endregion

    #region public Methods

    public async Task<Result<Unit, Error>> Handle(DeleteResumeCommand request, CancellationToken cancellationToken)
    {
        //var book = await _bookRepository.GetByIdAsync(request.BookId, GetIncludes());
        //if (book is null) { return Error.NotFound; }

        //var resume = book.Resumes.FirstOrDefault(x => x.Id == request.Id);
        //if (resume is null) { return Error.NotFound; }

        //var result = book.RemoveResume(resume);
        //if (result.IsFailure) { return result.Error; }

        //await _bookRepository.UpdateAsync(book);
        //await _bookRepository.SaveChangesAsync();

        return new Unit();
    }


    #endregion

    #region Includes
    //private Func<IQueryable<Book>, IIncludableQueryable<Book, object>> GetIncludes()
    //{
    //    return includes => includes
    //        .Include(b => b.Resumes);
    //}

    #endregion
}
