using Library.Application.Dtos.Book;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Features.Book.Queries.GetBookDetails
{
    public record GetBookDetailsQuery(int id) : IRequest<GetBookDetailsDto>;

}
