
using MyLibrary.Domain.Common;

namespace MyLibrary.Domain.Models
{
    public class LibraryBook : BaseEntity
    {
        #region Fields

        public long LibraryId { get; private set; }
        public Library Library { get; private set; }
        public long BookId { get; private set; }
        public Book Book { get; private set; }

        #endregion

        #region Builder

        private LibraryBook(long libraryId, long bookId)
        {
            LibraryId = libraryId;
            BookId = bookId;
        }

        #endregion

        #region Public methods

        #endregion

        #region Private

        #endregion
    }
}

