using AutoMapper;
using CSharpFunctionalExtensions;
using MediatR;
using MyLibrary.Application.Contracts.Logging;
using MyLibrary.Application.Contracts.Persistence;
using MyLibrary.Application.Exceptions;
using MyLibrary.Domain.Common;
using MyLibrary.Domain.Models;

namespace MyLibrary.Application.Features.BookFeature.Commands.CreateBook
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, Result<long, Error>>
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly IBookRepository _bookRepository;
        private readonly IAppLogger<CreateBookCommandHandler> _logger;

        #endregion

        #region Builder

        public CreateBookCommandHandler(IMapper mapper,
                                        IBookRepository bookRepository,
                                        IAppLogger<CreateBookCommandHandler> logger)
        {
            _mapper = mapper;
            _bookRepository = bookRepository;
            _logger = logger;
        }

        #endregion

        #region methods

        public async Task<Result<long, Error>> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var newBookResult = Book.Create(request.Title, request.AuthorName, request.Isbn, request.Price);
            if (newBookResult.IsFailure) { return newBookResult.Error; }

            await _bookRepository.CreateAsync(newBookResult.Value);
            await _bookRepository.SaveChangesAsync();

            return newBookResult.Value.Id;
        }

        #endregion

        #region Private methods

        #endregion
    }

}
