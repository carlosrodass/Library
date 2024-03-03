using MyLibrary.Domain.Common;

namespace MyLibrary.Domain.Models
{
    public class Hub : BaseEntity
    {
        public long HubId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int StatusId { get; set; }
        public Status Status { get; set; }
        public string UserId { get; set; }
        public List<Book> Books { get; set; }
        public List<BookHub> BookHubs { get; set; }

    }
}
