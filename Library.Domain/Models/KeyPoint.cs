using MyLibrary.Domain.Common;

namespace MyLibrary.Domain.Models
{


    public class KeyPoint : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Resume Resume { get; set; }
        public int ResumeId { get; set; }
    }
}

