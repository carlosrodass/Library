using CSharpFunctionalExtensions;
using MediatR;
using MyLibrary.Application.Contracts.Persistence;
using MyLibrary.Domain.Common;
using MyLibrary.Domain.Models;

namespace MyLibrary.Application.Features.HubFeature.Commands.AddBookToHub
{
    public class AddBookToHubCommandHandler : IRequestHandler<AddBookToHubCommand, Result<long, Error>>
    {
        private readonly IHubRepository _hubRepository;
        private readonly IBookRepository _bookRepository;
        public AddBookToHubCommandHandler(IHubRepository hubRepository, IBookRepository bookRepository)
        {
            _hubRepository = hubRepository;
            _bookRepository = bookRepository;
        }

        public async Task<Result<long, Error>> Handle(AddBookToHubCommand request, CancellationToken cancellationToken)
        {
            var hub = await _hubRepository.GetHubWithDetails(request.HubId);
            if (hub == null) { return Error.NotFound; }

            if (hub.Books.Any(x => x.BookId == request.BookId))
            {
                return Error.AlreadyExist;
            }

            var book = await _bookRepository.GetByIdAsync(request.BookId);
            if (book == null) { return Error.NotFound; }

            BookHub bookHub = new()
            {
                BookId = request.BookId,
                HubId = request.HubId
            };

            hub.BookHubs.Add(bookHub);
            await _hubRepository.SaveChangesAsync();
            return bookHub.BookId;

        }
    }
}
