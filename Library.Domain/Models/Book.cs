using MyLibrary.Domain.Common;
using MyLibrary.Domain.Models.Common;
using System.Reflection.Metadata;

namespace MyLibrary.Domain.Models
{
    public class Book : AggregateRoot
    {
        public string Title { get; private set; }
        public string AuthorName { get; private set; }
        public string Isbn { get; private set; }
        public long Price { get; private set; }
        public DateTime ReleaseDate { get; private set; }
        public string Image { get; private set; }
        public int Order { get; private set; }
        public Status Status { get; private set; }
        public int StatusId { get; private set; }
        public List<Resume> Resumes { get; private set; }
        public List<LibraryBook> LibraryBooks { get; set; }

        //public User User { get; set; }

        //public int UserId { get; set; }

        private Book(string title,
                     string authorName,
                     string isbn,
                     long price)
        {
            Title = title;
            AuthorName = authorName;
            Isbn = isbn;
            Price = price;
            StatusId = Status.Private.Id;
        }

        public static Book Create(string title, string authorName, string isbn, long price)
        {
            CheckRequiredBasicFields(title, authorName, isbn);

            return new Book(title, authorName, isbn, price);
        }

        public Book Update(string title, string authorName, string isbn, long price, DateTime releaseDate, string image, int order, int statusId)
        {

            CheckRequiredBasicFields(title, authorName, isbn);

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


        #region Private
        private static void CheckRequiredBasicFields(string title, string authorName, string isbn) //TODO: Add Result Pattern
        {
            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(authorName) || string.IsNullOrWhiteSpace(isbn))
            {

            }
        }
        #endregion

    }
}
