using MyLibrary.Application.Dtos.Resume;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Application.Dtos
{
    public class GetKeyPointDetailsDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long ResumeId { get; set; }
        public GetResumeDetailsDto Resume { get; set; }

    }
}
