using AutoMapper;
using MediatR;
using MyLibrary.Application.Contracts.Persistence;
using MyLibrary.Application.Exceptions;
using MyLibrary.Domain.Models;

namespace MyLibrary.Application.Features.BookFeature.Commands.UpdateBook
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, long>
    {
        private readonly IMapper _mapper;
        private readonly IBookRepository _bookRepository;

        public UpdateBookCommandHandler(IMapper mapper, IBookRepository bookRepository)
        {
            _mapper = mapper;
            _bookRepository = bookRepository;
        }
        public async Task<long> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetByIdAsync(request.Id);
            if (book == null)
            {
                //TODO: Add Result pattern and Return CustomError 
            }

            var resultUpdate = book.Update(request.Title, request.AuthorName, request.Isbn, request.Price, request.ReleaseDate, request.Image, request.Order, request.StatusId);
            //TODO: Add result Pattern

            await _bookRepository.UpdateAsync(book);
            await _bookRepository.SaveChangesAsync();

            return book.Id;
        }
    }
}


