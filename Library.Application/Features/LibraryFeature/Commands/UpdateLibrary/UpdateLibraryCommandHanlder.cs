using AutoMapper;
using MediatR;
using MyLibrary.Application.Contracts.Persistence;
using MyLibrary.Application.Exceptions;
using MyLibrary.Domain.Models;

namespace MyLibrary.Application.Features.LibraryFeature.Commands.UpdateLibrary;

public class UpdateLibraryCommandHanlder : IRequestHandler<UpdateLibraryCommand, int>
{
    private readonly ILibraryRepository _libraryRepository;
    private readonly IMapper _mapper;

    public UpdateLibraryCommandHanlder(ILibraryRepository libraryRepository, IMapper mapper)
    {
        _libraryRepository = libraryRepository;
        _mapper = mapper;
    }
    public async Task<int> Handle(UpdateLibraryCommand request, CancellationToken cancellationToken)
    {
        var library = await _libraryRepository.GetByIdAsync(request.Id);
        if (library == null) { throw new NotFoundException("library", request.Id); }

        library.Update(request.Name, request.Description, request.Image);

        await _libraryRepository.UpdateAsync(library);
        await _libraryRepository.SaveChangesAsync();

        return library.Id;
    }
}
