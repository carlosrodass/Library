using MyLibrary.Domain.Common;
using MyLibrary.Domain.Models.Common;
using System.Diagnostics;

namespace MyLibrary.Domain.Models
{

    public class Library : AggregateRoot
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public bool AllBooksReaded { get; set; }
        public int Order { get; set; }
        public Status Status { get; set; }
        public int StatusId { get; set; }
        public List<LibraryBook> LibraryBooks { get; set; }

        //public User User { get; set; }

        //public int UserId { get; set; }

        private Library(string name, string description, string image)
        {
            Name = name;
            Description = description;
            Image = image;
            LibraryBooks = new List<LibraryBook>();
        }


        public static Library Create(string name, string description, string image)
        {
            CheckRequiredBasicFields(name, description);
            return new Library(name, description, image);
        }

        public Library Update(string name, string description, string image)
        {
            CheckRequiredBasicFields(name, description);

            Name = name;
            Description = description;
            Image = image;
            return this;
        }

        // public Library AddBooks(List<Book> books)
        // {

        //     LibraryBooks.AddRange(books);


        //     return this;
        // }


        #region Private

        private static void CheckRequiredBasicFields(string name, string description) //TODO: Add Result Pattern
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(description))
            {

            }
        }
        #endregion

    }

}