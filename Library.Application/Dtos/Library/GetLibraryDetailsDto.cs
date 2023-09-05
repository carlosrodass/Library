using MyLibrary.Application.Dtos.Book;
using MyLibrary.Application.Dtos.Common;
using MyLibrary.Application.Dtos.LibraryBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Application.Dtos.Library
{
    public class GetLibraryDetailsDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public bool AllBooksReaded { get; set; }
        public int Order { get; set; }
        public EnumerationDto Status { get; set; }
        public int StatusId { get; set; }
        public List<LibraryBookDto> LibraryBooks { get; set; }

    }
}
