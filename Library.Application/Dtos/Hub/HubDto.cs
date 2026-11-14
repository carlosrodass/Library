using MyLibrary.Application.Dtos.Book;
using MyLibrary.Application.Dtos.BookHub;
using MyLibrary.Application.Dtos.Common;
using MyLibrary.Domain.Models;

namespace MyLibrary.Application.Dtos;

public class HubDto
{
    public long HubId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int StatusId { get; set; }
    public EnumerationDto Status { get; set; } = new EnumerationDto();
    public string UserId { get; set; }
    public List<BookDto> Books { get; set; }
    public int NumOfBooks { get; set; }

}
