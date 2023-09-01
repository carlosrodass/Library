using Library.Domain.Common;

namespace Library.Domain;

public class Resume : BaseEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Content { get; set; }
    public ResumeType ResumeType { get; set; }
    public int ResumeTypeId { get; set; }
    public Book Book { get; set; }
    public int BookId { get; set; }
    public IEnumerable<KeyPoint> KeyPoints { get; set; }

}

