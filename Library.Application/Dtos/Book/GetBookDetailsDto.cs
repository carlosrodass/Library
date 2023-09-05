
using MyLibrary.Application.Dtos.Common;
using MyLibrary.Application.Dtos.LibraryBook;

namespace MyLibrary.Application.Dtos.Book
{
    public class GetBookDetailsDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public string Isbn { get; set; }
        public long price { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Image { get; set; }
        public int Order { get; set; }
        public int StatusId { get; set; }
        public EnumerationDto Status { get; set; }
        public List<LibraryBookDto> LibraryBooks { get; set; }
        //public IEnumerable<ResumeDto> Resumes { get; set; }
    }

}
