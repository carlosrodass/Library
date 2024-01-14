using CSharpFunctionalExtensions;
using MediatR;
using MyLibrary.Application.Contracts.Persistence;
using MyLibrary.Application.Exceptions;
using MyLibrary.Domain.Common;

namespace MyLibrary.Application.Features.LibraryFeature.Commands.DeleteLibrary
{
    public class DeleteLibraryCommandHandler : IRequestHandler<DeleteLibraryCommand, Result<Unit, Error>>
    {
        private readonly ILibraryRepository _libraryRepository;

        public DeleteLibraryCommandHandler(ILibraryRepository libraryRepository)
        {
            _libraryRepository = libraryRepository;
        }
        public async Task<Result<Unit, Error>> Handle(DeleteLibraryCommand request, CancellationToken cancellationToken)
        {

            var result = await _libraryRepository.GetByIdAsync(request.Id);
            if (result is null) { return Error.NotFound; }

            await _libraryRepository.DeleteAsync(result);
            await _libraryRepository.SaveChangesAsync();

            return new Unit();
        }
    }
}
