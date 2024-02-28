using MyLibrary.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Domain.Models
{
    public class BookHub : BaseEntity
    {
        public long BookId { get; set; }
        public long HubId { get; set; }
        public Book Book { get; set; }
        public Hub Hub { get; set; }
    }
}
