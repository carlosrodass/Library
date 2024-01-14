using AutoMapper;
using CSharpFunctionalExtensions;
using MediatR;
using MyLibrary.Application.Contracts.Persistence;
using MyLibrary.Domain.Common;
using MyLibrary.Domain.Models;

namespace MyLibrary.Application.Features.ResumeFeature.Commands.CreateResume;

public class CreateResumeCommandHandler : IRequestHandler<CreateResumeCommand, Result<long, Error>>
{

    #region Fields

    private readonly IBookRepository _bookRepository;
    private readonly IMapper _mapper;

    #endregion

    #region Builder

    public CreateResumeCommandHandler(IBookRepository bookRepository, IMapper mapper)
    {
        _bookRepository = bookRepository;
        _mapper = mapper;
    }

    #endregion

    #region Public methods

    public async Task<Result<long, Error>> Handle(CreateResumeCommand request, CancellationToken cancellationToken)
    {
        var book = await _bookRepository.GetByIdAsync(request.BookId);
        if (book is null) { return Error.NotFound; }

        var result = Resume.Create(request.Title, request.Description, request.Content, request.ResumeTypeId, request.BookId);
        if (result.IsFailure) { return result.Error; }
        var resume = result.Value;

        var resultAddResume = book.AddBookResume(resume);
        if (resultAddResume.IsFailure) { return resultAddResume.Error; }

        await _bookRepository.UpdateAsync(book);
        await _bookRepository.SaveChangesAsync();

        return resume.Id;

    }
    #endregion
}
