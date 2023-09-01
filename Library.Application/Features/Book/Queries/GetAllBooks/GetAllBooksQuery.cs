using Library.Application.Dtos.Book;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Features.Book.Queries.GetAllBooks
{
    public record GetAllBooksQuery : IRequest<List<GetAllBooksDto>>;

}
