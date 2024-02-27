using AutoMapper;
using CSharpFunctionalExtensions;
using MediatR;
using MyLibrary.Application.Contracts.Persistence;
using MyLibrary.Domain.Common;

namespace MyLibrary.Application.Features.BookFeature.Commands.DeleteBook
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, Result<Unit, Error>>
    {
        private readonly IBookRepository _bookRepository;

        public DeleteBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<Result<Unit, Error>> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {

            var bookToDelete = await _bookRepository.GetByIdAsync(request.BookId);
            if (bookToDelete is null) { return Error.NotFound; }

            _bookRepository.Delete(bookToDelete);
            await _bookRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
