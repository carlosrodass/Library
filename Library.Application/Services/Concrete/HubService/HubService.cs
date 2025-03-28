using AutoMapper;
using CSharpFunctionalExtensions;
using MyLibrary.Application.Contracts.Persistence;
using MyLibrary.Application.Dtos;
using MyLibrary.Application.Dtos.Book;
using MyLibrary.Application.Services.Abstract.BookService;
using MyLibrary.Application.Services.Abstract.HubService;
using MyLibrary.Domain.Common;
using MyLibrary.Domain.Models;
using Hub = MyLibrary.Domain.Models.Hub;

namespace MyLibrary.Application.Services.Concrete.HubService;

internal sealed class HubService : IHubService
{
    #region Fields

    private readonly IMapper _mapper;
    private readonly IHubRepository _hubRepository;
    private readonly IBookService _bookService;

    #endregion

    #region Builder

    public HubService(IMapper mapper, IHubRepository hubRepository, IBookService bookService)
    {
        _mapper = mapper;
        _hubRepository = hubRepository;
        _bookService = bookService;
    }

    #endregion

    #region Public methods

    public async Task<Result<List<HubDto>, Error>> GetAllHubsByUserIdAsync(string userId)
    {
        var hubsList = await _hubRepository.GetHubsWithDetails(userId);
        if (hubsList == null) { return new List<HubDto>(); }

        List<HubDto> hubsDtoList = new List<HubDto>();
        foreach (var hubElement in hubsList)
        {
            HubDto hubDto = new HubDto();
            hubDto.HubId = hubElement.HubId;
            hubDto.Name = hubElement.Name;
            hubDto.Description = hubElement.Description;
            hubDto.Image = hubElement.Image;
            hubDto.Status.Id = hubElement.Status.Id;
            hubDto.Status.Name = hubElement.Status.Name;
            hubDto.StatusId = hubElement.Status.Id;

            hubsDtoList.Add(hubDto);
        }

        return hubsDtoList;
    }
    public async Task<Result<HubDto, Error>> GetHubByIdAsync(long hubId, string userId)
    {
        var hub = await GetHubById(hubId, userId);
        if (hub.IsFailure) { return hub.Error; }

        HubDto hubDto = _mapper.Map<HubDto>(hub.Value);

        SetNumberOfSummaries(hubDto.Books);

        return hubDto;
    }
    public async Task<Result<HubDto, Error>> CreateAsync(HubDto hubDto)
    {
        if (string.IsNullOrEmpty(hubDto.Name) || string.IsNullOrEmpty(hubDto.Description) || hubDto.StatusId == 0) { return CustomErrors.Hub.NotValid(); }

        Hub hub = new()
        {
            Name = hubDto.Name,
            Description = hubDto.Description,
            Image = hubDto.Image,
            StatusId = hubDto.StatusId,
            UserId = "e971878c-e3b4-471d-971b-dca461aae708"
        };

        await _hubRepository.CreateAsync(hub);
        await _hubRepository.SaveChangesAsync();

        return await GetHubByIdAsync(hub.HubId, "");
    }
    public async Task<Result<HubDto, Error>> UpdateAsync(HubDto hubDto)
    {
        bool isValidData = CheckUpdateHubData(hubDto);
        if (!isValidData) { return CustomErrors.Hub.NotValid(); }

        var hubFound = await GetHubById(hubDto.HubId, "Update");
        if (hubFound.IsFailure) { return hubFound.Error; }

        SetHubDataToUpdate(hubFound.Value, hubDto);

        _hubRepository.Update(hubFound.Value);
        await _hubRepository.SaveChangesAsync();

        var myHubToSend = _mapper.Map<HubDto>(hubFound.Value);
        await SetStatusToHubDto(hubFound.Value.StatusId, myHubToSend);

        return myHubToSend;

    }
    public async Task<Result<bool, Error>> DeleteAsync(long hubId)
    {
        var hubResult = await GetHubById(hubId, "");
        if (hubResult.IsFailure) { return hubResult.Error; }

        if (hubResult.Value.BookHubs != null && hubResult.Value.BookHubs.Any())
        {
            hubResult.Value.BookHubs = hubResult.Value.BookHubs = null;


            _hubRepository.Update(hubResult.Value);
            await _hubRepository.SaveChangesAsync();

        }

        _hubRepository.Delete(hubResult.Value);
        await _hubRepository.SaveChangesAsync();

        return true;

    }
    public async Task<Result<BookDto, Error>> CreateBookFromHub(BookDto bookDto)
    {
        var bookCreatedResult = await _bookService.CreateAsync(bookDto);
        if (bookCreatedResult.IsFailure) { return bookCreatedResult.Error; }

        var resultAddBookToHub = await AddBookToHub(bookDto.HubId.Value, bookCreatedResult.Value.BookId, "");
        if (resultAddBookToHub.IsFailure) { return resultAddBookToHub.Error; }

        return bookCreatedResult.Value;


    }
    public async Task<Result<bool, Error>> AddBookToHub(long hubId, long bookId, string userId)
    {
        var hub = await GetHubById(hubId, userId);
        if (hub.IsFailure) { return Error.NotFound; }

        if (hub.Value.Books.Any(x => x.BookId == bookId)) { return Error.AlreadyExist; }

        var book = await _bookService.GetBookByIdAsync(bookId);
        if (book.IsFailure) { return book.Error; }

        BookHub bookHub = new()
        {
            BookId = book.Value.BookId,
            HubId = hub.Value.HubId
        };

        if(hub.Value.BookHubs == null)
        {
            hub.Value.BookHubs = new List<BookHub>();
        }

        hub.Value.BookHubs.Add(bookHub);
        await _hubRepository.SaveChangesAsync();
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

    private void SetHubDataToUpdate(Hub hubFound, HubDto hubDto)
    {
        hubFound.Name = hubDto.Name;
        hubFound.Description = hubDto.Description;
        hubFound.Image = hubDto.Image;
        hubFound.StatusId = hubDto.StatusId;

    }

    private static bool CheckUpdateHubData(HubDto hubDto)
    {
        if (hubDto == null) { return false; }

        if (string.IsNullOrEmpty(hubDto.Name)) { return false; }

        if (string.IsNullOrEmpty(hubDto.Description)) { return false; }

        return true;
    }

    private static void SetNumberOfSummaries(List<BookDto> books)
    {
        books.ToList().ForEach(book => book.NumberOfSummaries = book.Resumes.Count);
    }

    private async Task SetStatusToHubDto(long statusIdToSearch, HubDto myHubToSend)
    {
        var status = await _hubRepository.GetHubStatusById(statusIdToSearch);
        myHubToSend.Status = new();
        myHubToSend.Status.Id = status.Id;
        myHubToSend.Status.Name = status.Name;
    }


    #endregion
}
