using Enum = Library.Domain.Common.Enum;

namespace Library.Domain;

public class ResumeType : Enum
{
    public static ResumeType Chapter { get; set; } = new(1, nameof(Chapter));
    public static ResumeType Full { get; set; } = new(2, nameof(Full));

    public static IEnumerable<ResumeType> List() =>
        new[] { Chapter, Full };

    private ResumeType(int id, string name) : base(id, name)
    {
    }
}

