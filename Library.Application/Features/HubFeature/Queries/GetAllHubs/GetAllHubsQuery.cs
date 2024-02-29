using CSharpFunctionalExtensions;
using MediatR;
using MyLibrary.Application.Dtos.Hub;
using MyLibrary.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Application.Features.HubFeature.Queries.GetAllHubs
{
    public record GetAllHubsQuery : IRequest<Result<List<GetAllHubsDto>, Error>>;
}
