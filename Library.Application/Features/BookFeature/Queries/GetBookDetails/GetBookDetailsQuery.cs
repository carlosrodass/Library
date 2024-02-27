using CSharpFunctionalExtensions;
using MediatR;
using MyLibrary.Application.Dtos.Book;
using MyLibrary.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Application.Features.BookFeature.Queries.GetBookDetails
{
    public record GetBookDetailsQuery(long BookId) : IRequest<Result<GetBookDetailsDto, Error>>;

}
