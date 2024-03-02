using AutoMapper;
using CSharpFunctionalExtensions;
using MediatR;
using MyLibrary.Application.Contracts.Logging;
using MyLibrary.Application.Contracts.Persistence;
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

            Book book = new()
            {
                Title = request.Title,
                AuthorName = request.AuthorName,
                Isbn = request.Isbn,
                Price = request.Price,
                ReleaseDate = request.ReleaseDate,
                Image = request.Image,
                Order = request.Order,
                StatusId = request.StatusId,
            };

            await _bookRepository.CreateAsync(book);
            await _bookRepository.SaveChangesAsync();

            return book.BookId;
        }

        #endregion
    }

}
