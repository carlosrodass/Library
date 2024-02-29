using CSharpFunctionalExtensions;
using MediatR;
using MyLibrary.Application.Contracts.Persistence;
using MyLibrary.Domain.Common;
using MyLibrary.Domain.Models;

namespace MyLibrary.Application.Features.HubFeature.Commands.CreateHub
{
    public class CreateHubCommandHandler : IRequestHandler<CreateHubCommand, Result<long, Error>>
    {

        private readonly IHubRepository _hubRepository;
        public CreateHubCommandHandler(IHubRepository hubRepository)
        {
            _hubRepository = hubRepository;
        }
        public async Task<Result<long, Error>> Handle(CreateHubCommand request, CancellationToken cancellationToken)
        {

            var hub = new Hub()
            {
                Name = request.Name,
                Description = request.Description,
                Image = request.Image,
                StatusId = request.StatusId,
            };

            await _hubRepository.CreateAsync(hub);
            await _hubRepository.SaveChangesAsync();

            return hub.HubId;
        }
    }
}
