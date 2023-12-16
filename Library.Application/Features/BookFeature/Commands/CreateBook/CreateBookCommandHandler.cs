using AutoMapper;
using MediatR;
using MyLibrary.Application.Contracts.Logging;
using MyLibrary.Application.Contracts.Persistence;
using MyLibrary.Application.Exceptions;
using MyLibrary.Domain.Common;
using MyLibrary.Domain.Models;

namespace MyLibrary.Application.Features.BookFeature.Commands.CreateBook
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, long>
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

        public async Task<long> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var newBook = Book.Create(request.Title, request.AuthorName, request.Isbn, request.Price); //TODO: Add Result pattern

            await _bookRepository.CreateAsync(newBook);
            await _bookRepository.SaveChangesAsync();

            return newBook.Id;
        }

        #endregion

        #region Private methods

        #endregion
    }

}
