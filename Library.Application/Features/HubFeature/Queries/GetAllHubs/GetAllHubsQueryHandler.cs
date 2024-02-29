using AutoMapper;
using CSharpFunctionalExtensions;
using MediatR;
using MyLibrary.Application.Contracts.Persistence;
using MyLibrary.Application.Dtos.Hub;
using MyLibrary.Domain.Common;

namespace MyLibrary.Application.Features.HubFeature.Queries.GetAllHubs
{
    public class GetAllHubsQueryHandler : IRequestHandler<GetAllHubsQuery, Result<List<GetAllHubsDto>, Error>>
    {
        private readonly IHubRepository _hubRepository;
        private readonly IMapper _mapper;
        public GetAllHubsQueryHandler(IHubRepository hubRepository, IMapper mapper)
        {
            _hubRepository = hubRepository;
            _mapper = mapper;
        }

        public async Task<Result<List<GetAllHubsDto>, Error>> Handle(GetAllHubsQuery request, CancellationToken cancellationToken)
        {
            var hubs = await _hubRepository.GetHubsWithDetails();
            if (hubs == null)
            {
                return new List<GetAllHubsDto>();
            }

            return _mapper.Map<List<GetAllHubsDto>>(hubs);
        }
    }
}
