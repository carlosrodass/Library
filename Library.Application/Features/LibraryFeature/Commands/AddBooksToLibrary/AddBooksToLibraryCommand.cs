using MediatR;
using MyLibrary.Application.Dtos.Book;
using MyLibrary.Application.Dtos.Library;
using MyLibrary.Application.Features.BookFeature.Commands.CreateBook;
using MyLibrary.Application.Features.BookFeature.Commands.UpdateBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Application.Features.LibraryFeature.Commands.AddBooksToLibrary
{
    public class AddBooksToLibraryCommand : IRequest<GetLibraryDetailsDto>
    {
        public int Id { get; set; }
        public List<UpdateBookCommand> Books { get; set; }
    }
}
