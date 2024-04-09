namespace MyLibrary.Domain.Common;

public abstract class CustomErrors
{

    public static class Book
    {
        private const string Code = "Book";
        public static Error NotFound() =>
            new Error(Code, "Book Not found");
    }

    public static class Hub
    {
        private const string Code = "Hub";
        public static Error NotFound() =>
            new Error(Code, "Hub Not found");

    }

}
