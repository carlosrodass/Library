using Enum = Library.Domain.Common.Enum;

namespace Library.Domain;

public class Status : Enum
{
    public static Status Private { get; set; } = new(1, nameof(Private));
    public static Status Public { get; set; } = new(2, nameof(Public));

    public static IEnumerable<Status> List() =>
        new[] { Private, Public };

    private Status(int id, string name) : base(id, name)
    {
    }
}
