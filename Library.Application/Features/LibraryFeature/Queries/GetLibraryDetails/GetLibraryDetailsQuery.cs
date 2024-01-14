using CSharpFunctionalExtensions;
using MediatR;
using MyLibrary.Application.Dtos.Library;
using MyLibrary.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Application.Features.LibraryFeature.Queries.GetLibraryDetails
{
    public record GetLibraryDetailsQuery(long Id) : IRequest<Result<GetLibraryDetailsDto, Error>>;

}

