using MyLibrary.Api.ViewModels.Book;
using MyLibrary.Api.ViewModels.Common;
using MyLibrary.Application.Dtos.Book;
using MyLibrary.Application.Dtos.Common;

namespace MyLibrary.Api.ViewModels.Hub;

public class HubInViewModel
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string? Image { get; set; }
    public int StatusId { get; set; }


}

public class HubUpdateViewModel : HubInViewModel
{
    public long HubId { get; set; }
}

public class HubViewModel : HubUpdateViewModel
{
    public EnumerationViewModel Status { get; set; }
    public List<BookViewModel> Books { get; set; }
    //public List<BookHubDto> BookHubs { get; set; }
}
