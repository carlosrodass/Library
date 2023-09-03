using AutoMapper;
using CSharpFunctionalExtensions;
using Library.Application.Contracts.Logging;
using Library.Application.Contracts.Persistence;
using Library.Application.Exceptions;
using Library.Domain.Common;
using MediatR;

namespace Library.Application.Features.Book.Commands.CreateBook
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
            this._mapper = mapper;
            this._bookRepository = bookRepository;
            this._logger = logger;
        }

        #endregion

        #region methods

        public async Task<int> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            await CheckValidFields(request);
            var newBook = _mapper.Map<Library.Domain.Book>(request);
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
