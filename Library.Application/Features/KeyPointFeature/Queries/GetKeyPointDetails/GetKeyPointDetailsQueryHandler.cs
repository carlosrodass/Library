using AutoMapper;
using CSharpFunctionalExtensions;
using MediatR;
using MyLibrary.Application.Contracts.Persistence;
using MyLibrary.Application.Dtos;
using MyLibrary.Domain.Common;

namespace MyLibrary.Application.Features.KeyPointFeature.Queries.GetKeyPointDetails
{
    public class GetKeyPointDetailsQueryHandler : IRequestHandler<GetKeyPointDetailsQuery, Result<GetKeyPointDetailsDto, Error>>
    {

        private readonly IKeyPointRepository _keyPointRepository;
        private readonly IMapper _mapper;

        public GetKeyPointDetailsQueryHandler(IKeyPointRepository keyPointRepository, IMapper mapper)
        {
            _keyPointRepository = keyPointRepository;
            _mapper = mapper;
        }

        public async Task<Result<GetKeyPointDetailsDto, Error>> Handle(GetKeyPointDetailsQuery request, CancellationToken cancellationToken)
        {
            var keyPoint = await _keyPointRepository.GetKeyPointWithDetails(request.KeyPointId);
            if (keyPoint == null) { return Error.NotFound; }

            return _mapper.Map<GetKeyPointDetailsDto>(keyPoint);

        }
    }

}
