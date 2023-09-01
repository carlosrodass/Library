using Library.Domain.Common;

namespace Library.Domain;

public class KeyPoint : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public Resume Resume { get; set; }
    public int ResumeId { get; set; }
}

