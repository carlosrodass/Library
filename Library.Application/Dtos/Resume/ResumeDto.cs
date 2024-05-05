

using MyLibrary.Application.Dtos.Book;
using MyLibrary.Application.Dtos.Common;
using MyLibrary.Domain.Models;

namespace MyLibrary.Application.Dtos.Resume;

public class ResumeDto
{
    public long ResumeId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Content { get; set; }
    public int ResumeTypeId { get; set; }
    public EnumerationDto ResumeType { get; set; }
    public long? BookId { get; set; }
    public BookDto Book { get; set; }
    //public ICollection<KeyPointDto> KeyPoints { get; set; }
}
