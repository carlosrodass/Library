using CSharpFunctionalExtensions;
using MyLibrary.Application.Dtos;
using MyLibrary.Application.Dtos.Book;
using MyLibrary.Domain.Common;

namespace MyLibrary.Application.Services.Abstract.HubService;

public interface IHubService
{
    Task<Result<HubDto, Error>> GetHubByIdAsync(long hubId, string userId);
    Task<Result<List<HubDto>, Error>> GetAllHubsByUserIdAsync(string userId);
    Task<Result<HubDto, Error>> CreateAsync(HubDto hubDto);
    Task<Result<HubDto, Error>> UpdateAsync(HubDto hubDto);
    Task<Result<bool, Error>> DeleteAsync(long hubId);
    Task<Result<BookDto, Error>> CreateBookFromHub(BookDto bookDto);
    Task<Result<bool, Error>> AddBookToHub(long hubId, long bookId, string userId);


}
