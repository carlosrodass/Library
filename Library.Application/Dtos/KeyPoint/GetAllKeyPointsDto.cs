using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Application.Dtos.KeyPoint
{
    public class GetAllKeyPointsDto
    {
        public long KeyPointId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
