using MediatR;
using MyLibrary.Application.Dtos.Library;
using MyLibrary.Application.Features.LibraryFeature.Commands.AddBooksToLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Application.Features.LibraryFeature.Commands.RemoveBooksFromLibrary
{
    public class RemoveBooksFromLibraryCommand : IRequest<GetLibraryDetailsDto>
    {
        public int Id { get; set; }
        public List<int> BooksIds { get; set; }
    }
}
