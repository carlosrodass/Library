using MyLibrary.Application.Dtos.Book;
using MyLibrary.Application.Dtos.Common;
using MyLibrary.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Application.Dtos.Resume
{
    public class GetResumeDetailsDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public EnumerationDto ResumeType { get; set; }
        public int ResumeTypeId { get; set; }
        public GetBookDetailsDto Book { get; set; }
        public int BookId { get; set; }
        //public IEnumerable<KeyPoint> KeyPoints { get; set; }
    }
}
