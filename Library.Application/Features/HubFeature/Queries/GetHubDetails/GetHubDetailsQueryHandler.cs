using AutoMapper;
using CSharpFunctionalExtensions;
using MediatR;
using MyLibrary.Application.Contracts.Persistence;
using MyLibrary.Application.Dtos.Hub;
using MyLibrary.Domain.Common;

namespace MyLibrary.Application.Features.HubFeature.Queries.GetHubDetails
{
    public class GetHubDetailsQueryHandler : IRequestHandler<GetHubDetailsQuery, Result<GetHubDetailsDto, Error>>
    {
        private readonly IHubRepository _hubRepository;
        private readonly IMapper _mapper;
        public GetHubDetailsQueryHandler(IHubRepository hubRepository, IMapper mapper)
        {
            _hubRepository = hubRepository;
            _mapper = mapper;
        }

        public async Task<Result<GetHubDetailsDto, Error>> Handle(GetHubDetailsQuery request, CancellationToken cancellationToken)
        {
            var hub = await _hubRepository.GetHubWithDetails(request.HubId);
            if (hub == null) { return Error.NotFound; }

            return _mapper.Map<GetHubDetailsDto>(hub);
        }
    }

}
