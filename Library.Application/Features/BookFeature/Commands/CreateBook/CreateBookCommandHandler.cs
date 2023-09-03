using AutoMapper;
using MediatR;
using MyLibrary.Application.Contracts.Logging;
using MyLibrary.Application.Contracts.Persistence;
using MyLibrary.Application.Exceptions;
using MyLibrary.Domain.Models;

namespace MyLibrary.Application.Features.BookFeature.Commands.CreateBook
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, int>
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly IBookRepository _bookRepository;
        private readonly IAppLogger<CreateBookCommandHandler> _logger;

        #endregion

        #region Builder

        public CreateBookCommandHandler(IMapper mapper, IBookRepository bookRepository, IAppLogger<CreateBookCommandHandler> logger)
        {
            _mapper = mapper;
            _bookRepository = bookRepository;
            _logger = logger;
        }

        #endregion

        #region methods

        public async Task<int> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            await CheckValidFields(request);
            var newBook = _mapper.Map<Book>(request);
            await _bookRepository.CreateAsync(newBook);
            await _bookRepository.SaveChangesAsync();
            return newBook.Id;
        }

        #endregion

        #region Private methods

        private async Task<bool> CheckValidFields(CreateBookCommand createBookCommand)
        {
            if (createBookCommand == null) { throw new BadRequestException("Book not provided"); }
            return true;
        }

        #endregion
    }

}
