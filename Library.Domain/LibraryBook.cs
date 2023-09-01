using Library.Domain.Common;

namespace Library.Domain;

public class LibraryBook : BaseEntity
{
    public int LibraryId { get; set; }
    public int BookId { get; set; }
}

