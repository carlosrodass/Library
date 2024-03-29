﻿using MyLibrary.Application.Dtos.Book;
using MyLibrary.Application.Dtos.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Application.Dtos.Hub
{
    public class GetHubDetailsDto
    {
        public long HubId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int StatusId { get; set; }
        public EnumerationDto Status { get; set; }
        public List<GetBookDetailsDto> Books { get; set; }

    }
}
