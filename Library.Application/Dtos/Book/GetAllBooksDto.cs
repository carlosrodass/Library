using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Dtos.Book
{
    public class GetAllBooksDto
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public string Image { get; set; }

    }
}
