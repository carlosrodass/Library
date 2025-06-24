using MyLibrary.Application.Dtos.Common;
using MyLibrary.Application.Dtos.Resume;

namespace MyLibrary.Application.Dtos.Book;

public class BookDto
{
    public long BookId { get; set; }
    public string Title { get; set; }
    public string AuthorName { get; set; }
    public string Isbn { get; set; }
    public long Price { get; set; }
    public DateTime ReleaseDate { get; set; }
    public DateTime? DateModified { get; set; }
    public string Image { get; set; }
    public int Order { get; set; }
    public EnumerationDto Status { get; set; }
    public int StatusId { get; set; }
    public int NumberOfSummaries { get; set; }
    public int? HubId { get; set; }

    public List<ResumeDto> Resumes { get; set; }
    //public List<HubDto> Hubs { get; set; }
    //public List<BookHubDto> BookHubs { get; set; }
}