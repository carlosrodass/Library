using AutoMapper;
using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using MyLibrary.Application.Contracts.Persistence;
using MyLibrary.Domain.Common;
using MyLibrary.Domain.Models;

namespace MyLibrary.Application.Features.ResumeFeature.Commands.CreateResume;

public class CreateResumeCommandHandler : IRequestHandler<CreateResumeCommand, Result<long, Error>>
{

    #region Fields

    private readonly IBookRepository _bookRepository;
    private readonly IResumeRepository _resumeRepository;
    private readonly IMapper _mapper;

    #endregion

    #region Builder

    public CreateResumeCommandHandler(IMapper mapper,
                                      IBookRepository bookRepository,
                                      IResumeRepository resumeRepository)
    {
        _mapper = mapper;
        _bookRepository = bookRepository;
        _resumeRepository = resumeRepository;
    }

    #endregion

    #region Public methods

    public async Task<Result<long, Error>> Handle(CreateResumeCommand request, CancellationToken cancellationToken)
    {
        var book = await _bookRepository.GetBookWithDetails(request.BookId);

        if (book is null)
        {
            return Error.NotFound;
        }

        if (book.Resume != null)
        {
            return Error.AlreadyExist;
        }

        Resume resume = new()
        {
            Title = request.Title,
            Description = request.Description,
            Content = request.Content,
            ResumeTypeId = request.ResumeTypeId,
            BookId = book.BookId
        };


        await _resumeRepository.CreateAsync(resume);

        book.Resume = resume;
        _bookRepository.Update(book);
        await _bookRepository.SaveChangesAsync();


        await _resumeRepository.SaveChangesAsync();

        return resume.ResumeId;

    }

    #endregion

}
