using AutoMapper;
using CSharpFunctionalExtensions;
using MyLibrary.Application.Contracts.Persistence;
using MyLibrary.Application.Dtos;
using MyLibrary.Application.Dtos.Book;
using MyLibrary.Application.Exceptions;
using MyLibrary.Application.Services.Abstract.BookService;
using MyLibrary.Application.Services.Abstract.HubService;
using MyLibrary.Domain.Common;
using MyLibrary.Domain.Models;
using static MyLibrary.Domain.Common.CustomErrors;
using Hub = MyLibrary.Domain.Models.Hub;

namespace MyLibrary.Application.Services.Concrete.HubService;

internal sealed class HubService : IHubService
{
    #region Fields

    private readonly IMapper _mapper;
    private readonly IHubRepository _hubRepository;
    private readonly IGenericRepository<BookHub> _genericRepository;
    private readonly IBookService _bookService;

    #endregion

    #region Builder

    public HubService(IMapper mapper, IHubRepository hubRepository, IBookService bookService, IGenericRepository<BookHub> genericRepository = null)

    {
        _mapper = mapper;
        _hubRepository = hubRepository;
        _bookService = bookService;
        _genericRepository = genericRepository;
    }

    #endregion

    #region Public methods

    public async Task<Result<List<HubDto>, Error>> GetAllHubsByUserIdAsync(string userId)
    {
        var hubsList = await _hubRepository.GetHubsWithDetails(userId);
        if (hubsList == null) { return new List<HubDto>(); }

        return hubsList;
    }

    public async Task<Result<HubDto, Error>> GetHubByIdAsync(long hubId, string userId)
    {
        var hub = await GetHubById(hubId, userId);
        if (hub.IsFailure) { return hub.Error; }

        HubDto hubDto = new HubDto()
        {
            HubId = hub.Value.HubId,
            Name = hub.Value.Name,
            Description = hub.Value.Description,
            StatusId = hub.Value.StatusId,
            Books = new List<BookDto>()
        };

        var resultAddBook = await SetBooksToHub(hubDto);
        if (resultAddBook.IsFailure) { return resultAddBook.Error; }

        SetNumberOfSummaries(hubDto.Books);

        return hubDto;
    }

    public async Task<Result<HubDto, Error>> CreateAsync(HubDto hubDto)
    {
        if (string.IsNullOrEmpty(hubDto.Name) || string.IsNullOrEmpty(hubDto.Description) || hubDto.StatusId == 0)
        {
            return CustomErrors.Hub.NotValid();
        }

        Hub hub = new()
        {
            Name = hubDto.Name,
            Description = hubDto.Description,
            StatusId = hubDto.StatusId,
            UserId = "e971878c-e3b4-471d-971b-dca461aae708"
        };

        await _hubRepository.CreateAsync(hub);
        await _hubRepository.SaveChangesAsync();

        return await GetHubByIdAsync(hub.HubId, "");
    }

    public async Task<Result<HubDto, Error>> UpdateAsync(HubDto hubDto)
    {

        var isValidData = CheckUpdateHubData(hubDto);
        if (!isValidData.Value) { return CustomErrors.Hub.NotValid(); }

        var hubFound = await GetHubById(hubDto.HubId, "Update");
        if (hubFound.IsFailure) { return hubFound.Error; }

        SetHubDataToUpdate(hubFound.Value, hubDto);

        _hubRepository.Update(hubFound.Value);
        await _hubRepository.SaveChangesAsync();

        return hubDto;
    }

    public async Task<Result<bool, Error>> DeleteAsync(long hubId)
    {
        var hubResult = await GetHubById(hubId, "");
        if (hubResult.IsFailure) { return hubResult.Error; }

        var hub = hubResult.Value;

        await RemoveBookHubRelation(hub.HubId);

        _hubRepository.Delete(hub);
        await _hubRepository.SaveChangesAsync();

        return true;

    }

    //public async Task<Result<bool, Error>> DeleteAsync(long hubId)
    //{
    //    var hubResult = await GetHubById(hubId, "");
    //    if (hubResult.IsFailure)
    //    {
    //        return hubResult.Error;
    //    }

    //    if (hubResult.Value.BookHubs != null && hubResult.Value.BookHubs.Any())
    //    {
    //        hubResult.Value.BookHubs = hubResult.Value.BookHubs = null;


    //        _hubRepository.Update(hubResult.Value);
    //        await _hubRepository.SaveChangesAsync();
    //    }

    //    _hubRepository.Delete(hubResult.Value);
    //    await _hubRepository.SaveChangesAsync();

    //    return true;
    //}

    public async Task<Result<BookDto, Error>> CreateBookFromHub(BookDto bookDto)
    {
        var bookCreatedResult = await _bookService.CreateAsync(bookDto);
        if (bookCreatedResult.IsFailure)
        {
            return bookCreatedResult.Error;
        }

        var resultAddBookToHub = await AddBookToHub(bookDto.HubId.Value, bookCreatedResult.Value.BookId, "");
        if (resultAddBookToHub.IsFailure)
        {
            return resultAddBookToHub.Error;
        }

        return bookCreatedResult.Value;
    }

    public async Task<Result<bool, Error>> AddBookToHub(long hubId, long bookId, string userId)
    {
        var hubResult = await GetHubById(hubId, userId);
        if (hubResult.IsFailure)
        {
            return Error.NotFound;
        }

        if (hubResult.Value.Books != null && hubResult.Value.Books.Any(x => x.BookId == bookId))
        {
            return Error.AlreadyExist;
        }

        var book = await _bookService.GetBookByIdAsync(bookId);
        if (book.IsFailure)
        {
            return book.Error;
        }

        BookHub bookHub = new()
        {
            BookId = bookId,
            HubId = hubId
        };

        if (hubResult.Value.BookHubs == null)
        {
            hubResult.Value.BookHubs = new List<BookHub>();
        }

        var resultAddBook = await _hubRepository.AddBookToHubAsync(bookHub);
        if (resultAddBook == false) { return Error.AlreadyExist; }

        return true;
    }

    #endregion

    #region Private methods

    private async Task<Result<Hub, Error>> GetHubById(long hubId, string userId)
    {
        var hub = await _hubRepository.GetHubWithDetails(hubId, userId);
        if (hub == null) { return CustomErrors.Hub.NotFound(); }

        return hub;
    }

    private static void SetNumberOfSummaries(List<BookDto> books)
    {
        books.ToList().ForEach(book => book.NumberOfSummaries = book.Resumes.Count);
    }

    private async Task<Result<bool, Error>> SetBooksToHub(HubDto hubDto)
    {
        var booksListResult = await _bookService.GetAllBooksByHubId(hubDto.HubId);

        if (booksListResult.IsFailure)
        {
            return booksListResult.Error;
        }

        if (booksListResult.Value.Count > 0)
        {
            hubDto.Books.AddRange(booksListResult.Value);
        }

        return true;
    }

    private Result<bool, Error> CheckUpdateHubData(HubDto hubDto)
    {

        if (hubDto == null) { return CustomErrors.Hub.NotValid(); }

        if (hubDto.HubId == 0) { return CustomErrors.Hub.NotValid(); }

        if (string.IsNullOrEmpty(hubDto.Name)) { return CustomErrors.Hub.NotValid(); }

        if (string.IsNullOrEmpty(hubDto.Description)) { return CustomErrors.Hub.NotValid(); }

        if (hubDto.StatusId == 0) { return CustomErrors.Hub.NotValid(); }


        return true;

    }

    private void SetHubDataToUpdate(Hub hubDb, HubDto hubDto)
    {

        hubDb.Name = hubDto.Name;
        hubDb.Description = hubDto.Description;
        hubDb.StatusId = hubDto.StatusId;

    }


    private async Task RemoveBookHubRelation(long hubId)
    {
        // Soft delete en las relaciones
        var bookHubsResult = await _hubRepository.GetBookHubByHubId(hubId);
        if (bookHubsResult != null && bookHubsResult.Any())
        {
            foreach (var bookHub in bookHubsResult)
            {
                _genericRepository.Delete(bookHub);
            }
        }
    }

    #endregion
}