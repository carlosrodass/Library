
using MyLibrary.Domain.Common;

namespace MyLibrary.Domain.Models
{
    public class LibraryBook : BaseEntity
    {
        public long LibraryId { get; set; }
        public Library Library { get; set; }
        public long BookId { get; set; }
        public Book Book { get; set; }

        private LibraryBook(long libraryId, long bookId)
        {
            LibraryId = libraryId;
            BookId = bookId;
        }

    }
}

