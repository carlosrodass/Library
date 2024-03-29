﻿using AutoMapper;
using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using MyLibrary.Application.Contracts.Persistence;
using MyLibrary.Domain.Common;
using MyLibrary.Domain.Models;

namespace MyLibrary.Application.Features.ResumeFeature.Commands.UpdateResume
{
    public class UpdateResumeCommandHandler : IRequestHandler<UpdateResumeCommand, Result<long, Error>>
    {

        #region Fields

        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        #endregion

        #region Builder

        public UpdateResumeCommandHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        #endregion

        #region Public methods

        public async Task<Result<long, Error>> Handle(UpdateResumeCommand request, CancellationToken cancellationToken)
        {
            //var book = await _bookRepository.GetByIdAsync(request.BookId);
            //if (book is null) { return Error.NotFound; }

            //var result = book.UpdateResume(request.Title, request.Description, request.Content);
            //if (result.IsFailure) { return result.Error; }

            //_bookRepository.UpdateAsync(result.Value);
            //await _bookRepository.SaveChangesAsync();

            //return book.BookId;

            throw new NotImplementedException();
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
}
