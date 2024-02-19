using CSharpFunctionalExtensions;
using MyLibrary.Domain.Common;
using MyLibrary.Domain.Models.Common;
using System.Reflection.Metadata;

namespace MyLibrary.Domain.Models
{
    public class Book : AggregateRoot
    {
        #region Fields

        public string Title { get; private set; }
        public string AuthorName { get; private set; }
        public string Isbn { get; private set; }
        public long Price { get; private set; }
        public DateTime ReleaseDate { get; private set; }
        public string Image { get; private set; }
        public int Order { get; private set; }
        public Status Status { get; private set; }
        public int StatusId { get; private set; }
        public Resume Resume { get; private set; }


        //public User User { get; set; }

        //public int UserId { get; set; }

        #endregion

        #region Builder

        protected Book()
        {

        }

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

        #endregion

        #region Book

        public static Result<Book, Error> Create(string title, string authorName, string isbn, long price)
        {
            var result = CheckRequiredBasicFields(title, authorName, isbn);
            if (result.IsFailure) { return result.Error; }

            return new Book(title, authorName, isbn, price);
        }

        public Result<Book, Error> Update(string title, string authorName, string isbn, long price, DateTime releaseDate, string image, int order, int statusId)
        {

            var result = CheckRequiredBasicFields(title, authorName, isbn);
            if (result.IsFailure) { return result.Error; }


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

        #endregion

        #region Resume
        public Result<Book, Error> AddBookResume(string title, string description, string content, int resumeTypeId, long bookId)
        {

            if (this.Resume is not null) { return Error.AlreadyExist; }

            var result = Resume.Create(title, description, content, resumeTypeId, bookId);
            if (result.IsFailure) { return result.Error; }

            Resume = result.Value;

            return this;
        }

        //public Result<Book, Error> RemoveResume(Resume resume)
        //{
        //    if (resume is null) { return Error.NotFound; }
        //    _resumes.Remove(resume);

        //    return this;
        //}

        #endregion

        #region Private
        private static Result<bool, Error> CheckRequiredBasicFields(string title, string authorName, string isbn)
        {
            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(authorName) || string.IsNullOrWhiteSpace(isbn))
            {
                return Error.RequiredField;
            }

            return true;
        }


        #endregion

    }
}
