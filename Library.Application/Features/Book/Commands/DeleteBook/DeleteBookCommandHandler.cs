using AutoMapper;
using Library.Application.Contracts.Persistence;
using MediatR;

namespace Library.Application.Features.Book.Commands.DeleteBook
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, Unit>
    {
        private readonly IBookRepository _bookRepository;

        public DeleteBookCommandHandler(IBookRepository bookRepository)
        {
            this._bookRepository = bookRepository;
        }
        public async Task<Unit> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            //TODO: Add validation

            var bookToDelete = await _bookRepository.GetByIdAsync(request.Id);

            await _bookRepository.DeleteAsync(bookToDelete);

            return Unit.Value;
        }
    }
}
