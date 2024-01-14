using AutoMapper;
using CSharpFunctionalExtensions;
using MediatR;
using MyLibrary.Application.Contracts.Persistence;
using MyLibrary.Application.Exceptions;
using MyLibrary.Domain.Common;
using MyLibrary.Domain.Models;

namespace MyLibrary.Application.Features.LibraryFeature.Commands.UpdateLibrary;

public class UpdateLibraryCommandHanlder : IRequestHandler<UpdateLibraryCommand, Result<long, Error>>
{
    private readonly ILibraryRepository _libraryRepository;
    private readonly IMapper _mapper;

    public UpdateLibraryCommandHanlder(ILibraryRepository libraryRepository, IMapper mapper)
    {
        _libraryRepository = libraryRepository;
        _mapper = mapper;
    }
    public async Task<Result<long, Error>> Handle(UpdateLibraryCommand request, CancellationToken cancellationToken)
    {
        var library = await _libraryRepository.GetByIdAsync(request.Id);
        if (library is null) { return Error.NotFound; }

        var result = library.Update(request.Name, request.Description, request.Image);
        if (result.IsFailure) { return result.Error; }


        await _libraryRepository.UpdateAsync(library);
        await _libraryRepository.SaveChangesAsync();

        return library.Id;
    }
}
