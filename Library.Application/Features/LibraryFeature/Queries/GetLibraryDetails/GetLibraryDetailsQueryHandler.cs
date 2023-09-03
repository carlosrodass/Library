using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using MyLibrary.Application.Contracts.Persistence;
using MyLibrary.Application.Dtos.Library;
using MyLibrary.Application.Exceptions;
using MyLibrary.Domain.Models;

namespace MyLibrary.Application.Features.LibraryFeature.Queries.GetLibraryDetails
{

    public class GetLibraryDetailsQueryHandler : IRequestHandler<GetLibraryDetailsQuery, GetLibraryDetailsDto>
    {
        private readonly ILibraryRepository _libraryRepository;
        private readonly IMapper _mapper;

        public GetLibraryDetailsQueryHandler(ILibraryRepository libraryRepository, IMapper mapper)
        {
            _libraryRepository = libraryRepository;
            _mapper = mapper;
        }

        public async Task<GetLibraryDetailsDto> Handle(GetLibraryDetailsQuery request, CancellationToken cancellationToken)
        {
            var result = await _libraryRepository.GetByIdAsync(request.Id, GetIncludes());
            if (result == null) { throw new NotFoundException("Library", request.Id); }
            return _mapper.Map<GetLibraryDetailsDto>(result);

        }


        private Func<IQueryable<Library>, IIncludableQueryable<Library, object>> GetIncludes()
        {
            return includes => includes
                .Include(b => b.Status);
        }
    }
}