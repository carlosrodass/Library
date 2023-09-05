using MediatR;
using MyLibrary.Application.Contracts.Persistence;
using MyLibrary.Application.Exceptions;

namespace MyLibrary.Application.Features.LibraryFeature.Commands.DeleteLibrary
{
    public class DeleteLibraryCommandHandler : IRequestHandler<DeleteLibraryCommand, Unit>
    {
        private readonly ILibraryRepository _libraryRepository;

        public DeleteLibraryCommandHandler(ILibraryRepository libraryRepository)
        {
            this._libraryRepository = libraryRepository;
        }
        public async Task<Unit> Handle(DeleteLibraryCommand request, CancellationToken cancellationToken)
        {

            var result = await _libraryRepository.GetByIdAsync(request.Id);
            if (result == null) { throw new NotFoundException("Library not found", request.Id); }

            await _libraryRepository.DeleteAsync(result);
            await _libraryRepository.SaveChangesAsync();

            return new Unit();
        }
    }
}
