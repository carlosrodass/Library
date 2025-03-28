namespace MyLibrary.Api.ViewModels.Book
{
    public class BookInViewModel
    {
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public string Isbn { get; set; }
        public long Price { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Image { get; set; }
        public int Order { get; set; }
        public int StatusId { get; set; }
        public int? HubId { get; set; }
    }



    public class BookUpdateViewModel : BookInViewModel
    {
        public long BookId { get; set; }
    }


    public class BookViewModel : BookUpdateViewModel
    {
        public int NumberOfSummaries { get; set; }
        public DateTime? DateModified { get; set; }
    }






}
