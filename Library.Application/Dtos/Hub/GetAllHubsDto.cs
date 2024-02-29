using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Application.Dtos.Hub
{
    public class GetAllHubsDto
    {
        public long HubId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int StatusId { get; set; }
    }
}
