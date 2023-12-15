using AutoMapper;
using MediatR;
using MyLibrary.Application.Contracts.Persistence;

namespace MyLibrary.Application.Features.BookFeature.Commands.DeleteBook
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, Unit>
    {
        private readonly IBookRepository _bookRepository;

        public DeleteBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<Unit> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            
            var bookToDelete = await _bookRepository.GetByIdAsync(request.Id);
            if (bookToDelete == null)
            {
                //TODO: Add Result pattern and Return CustomError 
            }

            await _bookRepository.DeleteAsync(bookToDelete);
            await _bookRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
