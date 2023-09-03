using AutoMapper;
using MediatR;
using MyLibrary.Application.Contracts.Persistence;
using MyLibrary.Application.Exceptions;
using MyLibrary.Domain.Models;

namespace MyLibrary.Application.Features.LibraryFeature.Commands.CreateLibrary;

public class CreateLibraryCommandHandler : IRequestHandler<CreateLibraryCommand, int>
{
    private readonly ILibraryRepository _libraryRepository;
    private readonly IMapper _mapper;

    public CreateLibraryCommandHandler(ILibraryRepository libraryRepository, IMapper mapper)
    {
        _libraryRepository = libraryRepository;
        _mapper = mapper;
    }

    public async Task<int> Handle(CreateLibraryCommand request, CancellationToken cancellationToken)
    {
        await CheckValidFields(request);
        var newLibrary = _mapper.Map<Library>(request);
        await _libraryRepository.CreateAsync(newLibrary);
        await _libraryRepository.SaveChangesAsync();
        return newLibrary.Id;
    }


    private async Task<bool> CheckValidFields(CreateLibraryCommand request)
    {
        if (request == null) { throw new BadRequestException("library not provided"); }
        return true;
    }
}
