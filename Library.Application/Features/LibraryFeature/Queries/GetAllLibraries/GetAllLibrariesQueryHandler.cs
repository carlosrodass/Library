using AutoMapper;
using MediatR;
using MyLibrary.Application.Contracts.Persistence;
using MyLibrary.Application.Dtos.Library;

namespace MyLibrary.Application.Features.LibraryFeature.Queries.GetAllLibraries;

public class GetAllLibrariesQueryHandler : IRequestHandler<GetAllLibrariesQuery, List<GetAllLibrariesDto>>
{
    private readonly ILibraryRepository _libraryRepository;
    private readonly IMapper _mapper;

    public GetAllLibrariesQueryHandler(ILibraryRepository libraryRepository, IMapper mapper)
    {
        _libraryRepository = libraryRepository;
        _mapper = mapper;
    }

    public async Task<List<GetAllLibrariesDto>> Handle(GetAllLibrariesQuery request, CancellationToken cancellationToken)
    {
        var resultList = await _libraryRepository.GetAsync();
        return _mapper.Map<List<GetAllLibrariesDto>>(resultList);
    }
}
