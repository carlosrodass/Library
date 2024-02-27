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
        public long ResumeId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public int ResumeTypeId { get; set; }
        public EnumerationDto ResumeType { get; set; }
        public List<GetKeyPointDetailsDto> KeyPoints { get; set; }
    }
}
