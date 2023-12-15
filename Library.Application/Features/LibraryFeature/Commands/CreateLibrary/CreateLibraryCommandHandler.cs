using AutoMapper;
using MediatR;
using MyLibrary.Application.Contracts.Persistence;
using MyLibrary.Application.Exceptions;
using MyLibrary.Domain.Models;

namespace MyLibrary.Application.Features.LibraryFeature.Commands.CreateLibrary;

public class CreateLibraryCommandHandler : IRequestHandler<CreateLibraryCommand, long>
{
    private readonly ILibraryRepository _libraryRepository;
    private readonly IMapper _mapper;

    public CreateLibraryCommandHandler(ILibraryRepository libraryRepository, IMapper mapper)
    {
        _libraryRepository = libraryRepository;
        _mapper = mapper;
    }

    public async Task<long> Handle(CreateLibraryCommand request, CancellationToken cancellationToken)
    {
        if (request == null)
        {
            //TODO: Add Result Pattern
        }

        var result = Library.Create(request.Name, request.Description, request.Image);
        //TODO: Add result Pattern

        await _libraryRepository.CreateAsync(result);
        await _libraryRepository.SaveChangesAsync();

        return result.Id;
    }

}
