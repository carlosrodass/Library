using AutoMapper;
using MediatR;
using MyLibrary.Application.Contracts.Persistence;
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
        //TODO: Add Validator 
        //TODO: Add exception handler

        var update = _mapper.Map<Library>(request);

        await _libraryRepository.UpdateAsync(update);
        await _libraryRepository.SaveChangesAsync();

        return update.Id;
    }
}
