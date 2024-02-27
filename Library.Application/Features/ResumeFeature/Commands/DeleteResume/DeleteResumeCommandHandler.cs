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
    private readonly IResumeRepository _resumeRepository;
    private readonly IMapper _mapper;

    #endregion

    #region Builder

    public DeleteResumeCommandHandler(IMapper mapper, IBookRepository bookRepository, IResumeRepository resumeRepository)
    {
        _mapper = mapper;
        _bookRepository = bookRepository;
        _resumeRepository = resumeRepository;
    }

    #endregion

    #region public Methods

    public async Task<Result<Unit, Error>> Handle(DeleteResumeCommand request, CancellationToken cancellationToken)
    {
        var resume = await _resumeRepository.GetByIdAsync(request.ResumeId);
        if (resume == null) { return Error.NotFound; }

        _resumeRepository.Delete(resume);
        await _resumeRepository.SaveChangesAsync();

        //var book = await _bookRepository.GetByIdAsync(request.BookId);
        //if (book is null) { return Error.NotFound; }

        //var result = book.RemoveResume();
        //if (result.IsFailure) { return result.Error; }

        //_bookRepository.UpdateAsync(book);
        //await _bookRepository.SaveChangesAsync();

        return new Unit();
    }


    #endregion

    #region Includes
    private Func<IQueryable<Book>, IIncludableQueryable<Book, object>> GetIncludes()
    {
        return includes => includes
            .Include(b => b.Resume);
    }

    #endregion
}
