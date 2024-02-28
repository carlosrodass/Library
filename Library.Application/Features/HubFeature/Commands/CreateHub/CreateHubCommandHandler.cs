using CSharpFunctionalExtensions;
using MediatR;
using MyLibrary.Domain.Common;

namespace MyLibrary.Application.Features.HubFeature.Commands.CreateHub
{
    public class CreateHubCommandHandler : IRequestHandler<CreateHubCommand, Result<long, Error>>
    {


        public CreateHubCommandHandler()
        {

        }
        public async Task<Result<long, Error>> Handle(CreateHubCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
