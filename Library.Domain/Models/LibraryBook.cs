
using MyLibrary.Domain.Common;

namespace MyLibrary.Domain.Models
{
    public class LibraryBook : BaseEntity
    {
        public int LibraryId { get; set; }
        public Library Library { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}

