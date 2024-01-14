using CSharpFunctionalExtensions;
using MyLibrary.Domain.Common;
using MyLibrary.Domain.Models.Common;
using System.Diagnostics;

namespace MyLibrary.Domain.Models
{

    public class Library : AggregateRoot
    {
        #region Fields

        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Image { get; private set; }
        public bool AllBooksReaded { get; private set; }
        public int Order { get; private set; }
        public Status Status { get; private set; }
        public int StatusId { get; private set; }

        public readonly List<LibraryBook> _libraryBooks;
        public IReadOnlyCollection<LibraryBook> LibraryBooks => _libraryBooks;

        //public User User { get; set; }

        //public int UserId { get; set; }

        #endregion

        #region Builder

        protected Library()
        {
            _libraryBooks = new List<LibraryBook>();
        }

        private Library(string name, string description, string image)
        {
            Name = name;
            Description = description;
            Image = image;

        }

        #endregion

        #region Public methods

        public static Result<Library, Error> Create(string name, string description, string image)
        {
            var result = CheckRequiredBasicFields(name, description);
            if (result.IsFailure) { return result.Error; }

            return new Library(name, description, image);
        }

        public Result<Library, Error> Update(string name, string description, string image)
        {
            var result = CheckRequiredBasicFields(name, description);
            if (result.IsFailure) { return result.Error; }

            Name = name;
            Description = description;
            Image = image;
            return this;
        }

        #endregion

        #region Private

        private static Result<bool, Error> CheckRequiredBasicFields(string name, string description)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(description))
            {
                return Error.RequiredField;
            }

            return true;
        }
        #endregion

    }

}