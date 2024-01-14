using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using MyLibrary.Application.Contracts.Persistence;
using MyLibrary.Application.Dtos.Library;
using MyLibrary.Application.Exceptions;
using MyLibrary.Domain.Models;
using MyLibrary.Domain.Common;
using CSharpFunctionalExtensions;

namespace MyLibrary.Application.Features.LibraryFeature.Queries.GetLibraryDetails
{

    public class GetLibraryDetailsQueryHandler : IRequestHandler<GetLibraryDetailsQuery, Result<GetLibraryDetailsDto, Error>>
    {
        private readonly ILibraryRepository _libraryRepository;
        private readonly IMapper _mapper;

        public GetLibraryDetailsQueryHandler(ILibraryRepository libraryRepository, IMapper mapper)
        {
            _libraryRepository = libraryRepository;
            _mapper = mapper;
        }

        public async Task<Result<GetLibraryDetailsDto, Error>> Handle(GetLibraryDetailsQuery request, CancellationToken cancellationToken)
        {
            var result = await _libraryRepository.GetByIdAsync(request.Id, GetIncludes());
            if (result is null) { return Error.NotFound; }
            return _mapper.Map<GetLibraryDetailsDto>(result);
        }


        private Func<IQueryable<Library>, IIncludableQueryable<Library, object>> GetIncludes()
        {
            return includes => includes
                .Include(b => b.Status)
                .Include(b => b.LibraryBooks).ThenInclude(x => x.Book);
        }
    }
}