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
        public int Id { get; set; }
        public int LibraryId { get; set; }
        public GetLibraryDetailsDto Library { get; set; }
        public int BookId { get; set; }
        public GetBookDetailsDto Book { get; set; }
    }
}
