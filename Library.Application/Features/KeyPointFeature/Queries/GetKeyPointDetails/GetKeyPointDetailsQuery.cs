using CSharpFunctionalExtensions;
using MediatR;
using MyLibrary.Application.Dtos;
using MyLibrary.Application.Dtos.KeyPoint;
using MyLibrary.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Application.Features.KeyPointFeature.Queries.GetKeyPointDetails
{
    public record GetKeyPointDetailsQuery(long KeyPointId) : IRequest<Result<GetKeyPointDetailsDto, Error>>;

}
