using AutoMapper;
using CSharpFunctionalExtensions;
using MediatR;
using MyLibrary.Application.Contracts.Persistence;
using MyLibrary.Application.Dtos.Library;
using MyLibrary.Domain.Common;

namespace MyLibrary.Application.Features.LibraryFeature.Queries.GetAllLibraries;

public class GetAllLibrariesQueryHandler : IRequestHandler<GetAllLibrariesQuery, Result<List<GetAllLibrariesDto>, Error>>
{
    private readonly ILibraryRepository _libraryRepository;
    private readonly IMapper _mapper;

    public GetAllLibrariesQueryHandler(ILibraryRepository libraryRepository, IMapper mapper)
    {
        _libraryRepository = libraryRepository;
        _mapper = mapper;
    }

    public async Task<Result<List<GetAllLibrariesDto>, Error>> Handle(GetAllLibrariesQuery request, CancellationToken cancellationToken)
    {
        var resultList = await _libraryRepository.GetAsync();
        if (resultList.Count == 0) { return new List<GetAllLibrariesDto>(); }

        return _mapper.Map<List<GetAllLibrariesDto>>(resultList);
    }
}
