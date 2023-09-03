
using MyLibrary.Domain.Common;

namespace MyLibrary.Domain.Models
{
    public class LibraryBook : BaseEntity
    {
        public int LibraryId { get; set; }
        public int BookId { get; set; }
    }
}

