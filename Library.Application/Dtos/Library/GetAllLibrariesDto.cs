using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Application.Dtos.Library
{
    public class GetAllLibrariesDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public bool AllBooksReaded { get; set; }
        public int Order { get; set; }

    }
}
