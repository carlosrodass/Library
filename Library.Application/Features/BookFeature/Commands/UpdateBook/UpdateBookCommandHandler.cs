using AutoMapper;
using CSharpFunctionalExtensions;
using MediatR;
using MyLibrary.Application.Contracts.Persistence;
using MyLibrary.Application.Exceptions;
using MyLibrary.Domain.Common;
using MyLibrary.Domain.Models;

namespace MyLibrary.Application.Features.BookFeature.Commands.UpdateBook
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, Result<long, Error>>
    {
        private readonly IMapper _mapper;
        private readonly IBookRepository _bookRepository;

        public UpdateBookCommandHandler(IMapper mapper, IBookRepository bookRepository)
        {
            _mapper = mapper;
            _bookRepository = bookRepository;
        }
        public async Task<Result<long, Error>> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetByIdAsync(request.Id);
            if (book is null) { return Error.NotFound; }

            var resultUpdate = book.Update(request.Title, request.AuthorName, request.Isbn, request.Price, request.ReleaseDate, request.Image, request.Order, request.StatusId);
            if (resultUpdate.IsFailure) { return resultUpdate.Error; }
            
            await _bookRepository.UpdateAsync(book);
            await _bookRepository.SaveChangesAsync();

            return book.Id;
        }
    }
}


