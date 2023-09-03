using MediatR;
using MyLibrary.Application.Dtos.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Application.Features.BookFeature.Queries.GetAllBooks
{
    public record GetAllBooksQuery : IRequest<List<GetAllBooksDto>>;

}
