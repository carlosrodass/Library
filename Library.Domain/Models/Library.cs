using MyLibrary.Domain.Common;

namespace MyLibrary.Domain.Models
{

    public class Library : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public bool AllBooksReaded { get; set; }
        public int Order { get; set; }
        public Status Status { get; set; }
        public int StatusId { get; set; }

        //public User User { get; set; }

        //public int UserId { get; set; }


    }

}