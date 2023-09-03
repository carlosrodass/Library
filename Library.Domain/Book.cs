using Library.Domain.Common;



namespace Library.Domain;

public class Book : BaseEntity
{
    public string Title { get; set; }
    public string AuthorName { get; set; }
    public string Isbn { get; set; }
    public long Price { get; set; }
    public DateTime ReleaseDate { get; set; }
    public string Image { get; set; }
    public int Order { get; set; }
    public IEnumerable<Resume> Resumes { get; set; }
    public Status Status { get; set; }
    public int StatusId { get; set; }

    //public User User { get; set; }

    //public int UserId { get; set; }
}

