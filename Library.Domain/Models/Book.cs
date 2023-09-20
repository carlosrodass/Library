using MyLibrary.Domain.Common;
using System.Reflection.Metadata;

namespace MyLibrary.Domain.Models
{
    public class Book : BaseEntity
    {
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
        public List<LibraryBook> LibraryBooks { get; set; }

        //public User User { get; set; }

        //public int UserId { get; set; }

        public Book Update(string title, string authorName, string isbn, long price, DateTime releaseDate, string image, int order, int statusId)
        {
            Title = title;
            AuthorName = authorName;
            Isbn = isbn;
            Price = price;
            ReleaseDate = releaseDate;
            Image = image;
            Order = order;
            StatusId = statusId;

            return this;
        }

    }
}
