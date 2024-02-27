using AutoMapper;
using CSharpFunctionalExtensions;
using MediatR;
using MyLibrary.Application.Contracts.Persistence;
using MyLibrary.Application.Dtos.KeyPoint;
using MyLibrary.Domain.Common;

namespace MyLibrary.Application.Features.KeyPointFeature.Queries.GetAllKeyPoints
{
    public class GetAllKeyPointsQueryHandler : IRequestHandler<GetAllKeyPointsQuery, Result<List<GetAllKeyPointsDto>, Error>>
    {
        private readonly IKeyPointRepository _keyPointRepository;
        private readonly IMapper _mapper;
        public GetAllKeyPointsQueryHandler(IKeyPointRepository keyPointRepository, IMapper mapper)
        {
            _keyPointRepository = keyPointRepository;
            _mapper = mapper;
        }

        public async Task<Result<List<GetAllKeyPointsDto>, Error>> Handle(GetAllKeyPointsQuery request, CancellationToken cancellationToken)
        {
            var keyPoints = await _keyPointRepository.GetAsync();
            if (keyPoints.Count < 0)
            {
                return new List<GetAllKeyPointsDto>();
            }
            return _mapper.Map<List<GetAllKeyPointsDto>>(keyPoints);

        }
    }

}
