
using MyLibrary.Application.Dtos.Common;
using MyLibrary.Application.Dtos.Resume;

namespace MyLibrary.Application.Dtos.Book
{
    public class GetBookDetailsDto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public string Isbn { get; set; }
        public long Price { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Image { get; set; }
        public int Order { get; set; }
        public int StatusId { get; set; }
        public EnumerationDto Status { get; set; }
        public long LibraryId { get; set; }
        public GetResumeDetailsDto Resume { get; set; }
    }

}
