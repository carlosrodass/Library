using CSharpFunctionalExtensions;
using MyLibrary.Domain.Common;


using System.Reflection.Metadata;

namespace MyLibrary.Domain.Models
{
    public class Book : BaseEntity
    {
        public long BookId { get; set; }
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public string Isbn { get; set; }
        public long Price { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Image { get; set; }
        public int Order { get; set; }
        public Status Status { get; set; }
        public int StatusId { get; set; }
        public List<Resume> Resumes { get; set; }
        public List<Hub> Hubs { get; set; }
        public List<BookHub> BookHubs { get; set; }

        //public User User { get; set; }

        //public int UserId { get; set; }

    }
}
