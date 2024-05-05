using CSharpFunctionalExtensions;
using Microsoft.VisualBasic;
using MyLibrary.Domain.Common;


namespace MyLibrary.Domain.Models
{
    public class Resume : BaseEntity
    {
        public long ResumeId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public int ResumeTypeId { get; set; }
        public ResumeType ResumeType { get; set; }
        public long? BookId { get; set; }
        public Book Book { get; set; }
        public ICollection<KeyPoint> KeyPoints { get; set; }

    }
}
