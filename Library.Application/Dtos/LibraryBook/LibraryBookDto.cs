using MyLibrary.Application.Dtos.Book;
using MyLibrary.Application.Dtos.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Application.Dtos.LibraryBook
{
    public class LibraryBookDto
    {
        public long Id { get; set; }
        public long LibraryId { get; set; }
        public GetLibraryDetailsDto Library { get; set; }
        public long BookId { get; set; }
        public GetBookDetailsDto Book { get; set; }
    }
}
