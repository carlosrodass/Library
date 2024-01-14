using AutoMapper;
using CSharpFunctionalExtensions;
using MediatR;
using MyLibrary.Application.Contracts.Persistence;
using MyLibrary.Application.Exceptions;
using MyLibrary.Domain.Common;
using MyLibrary.Domain.Models;

namespace MyLibrary.Application.Features.LibraryFeature.Commands.CreateLibrary;

public class CreateLibraryCommandHandler : IRequestHandler<CreateLibraryCommand, Result<long, Error>>
{
    private readonly ILibraryRepository _libraryRepository;
    private readonly IMapper _mapper;

    public CreateLibraryCommandHandler(ILibraryRepository libraryRepository, IMapper mapper)
    {
        _libraryRepository = libraryRepository;
        _mapper = mapper;
    }

    public async Task<Result<long, Error>> Handle(CreateLibraryCommand request, CancellationToken cancellationToken)
    {
        var result = Library.Create(request.Name, request.Description, request.Image);
        if (result.IsFailure) { return result.Error; }

        await _libraryRepository.CreateAsync(result.Value);
        await _libraryRepository.SaveChangesAsync();

        return result.Value.Id;
    }

}
