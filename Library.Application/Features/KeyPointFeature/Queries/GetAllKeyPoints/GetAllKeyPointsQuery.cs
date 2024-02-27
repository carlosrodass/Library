using CSharpFunctionalExtensions;
using MediatR;
using MyLibrary.Application.Dtos.KeyPoint;
using MyLibrary.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Application.Features.KeyPointFeature.Queries.GetAllKeyPoints
{
    public record GetAllKeyPointsQuery : IRequest<Result<List<GetAllKeyPointsDto>, Error>>;

}
