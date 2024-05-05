using AutoMapper;
using CSharpFunctionalExtensions;
using MyLibrary.Application.Contracts.Persistence;
using MyLibrary.Application.Dtos;
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
    private readonly IBookRepository _bookRepository;

    #endregion

    #region Builder

    public HubService(IMapper mapper, IHubRepository hubRepository, IBookRepository bookRepository)
    {
        _mapper = mapper;
        _hubRepository = hubRepository;
        _bookRepository = bookRepository;
    }

    #endregion

    #region Public methods

    public async Task<Result<List<HubDto>, Error>> GetAllHubsByUserIdAsync(string userId)
    {
        var hubsList = await _hubRepository.GetHubsWithDetails(userId);
        if (hubsList == null) { return new List<HubDto>(); }
        return _mapper.Map<List<HubDto>>(hubsList);

    }
    public async Task<Result<HubDto, Error>> GetHubByIdAsync(long hubId, string userId)
    {
        var hub = await GetHubById(hubId, userId);
        if (hub.IsFailure) { return hub.Error; }

        return _mapper.Map<HubDto>(hub.Value);
    }
    public async Task<Result<HubDto, Error>> CreateAsync(HubDto hubDto)
    {
        //TODO: Check required fields
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

        return _mapper.Map<HubDto>(hub);
    }
    public async Task<Result<HubDto, Error>> UpdateAsync(HubDto hubDto)
    {
        bool isValidData = CheckUpdateHubData(hubDto);
        if (!isValidData) { return CustomErrors.Hub.NotValid(); }

        var hubFound = await GetHubById(hubDto.HubId, "Update");
        if (hubFound.IsFailure) { return hubFound.Error; }

        HubDataToUpdate(hubFound.Value, hubDto);

        _hubRepository.Update(hubFound.Value);
        await _hubRepository.SaveChangesAsync();

        return _mapper.Map<HubDto>(hubFound.Value);
    }
    public async Task<Result<bool, Error>> DeleteAsync(long hubId)
    {
        throw new NotImplementedException();
    }
    public async Task<Result<bool, Error>> AddBookToHub(long hubId, long bookId, string userId)
    {
        var hub = await GetHubById(hubId, userId);
        if (hub.IsFailure) { return Error.NotFound; }

        if (hub.Value.Books.Any(x => x.BookId == bookId)) { return Error.AlreadyExist; }

        var book = await _bookRepository.GetByIdAsync(bookId);
        if (book == null) { return Error.NotFound; }

        BookHub bookHub = new()
        {
            BookId = book.BookId,
            HubId = hub.Value.HubId
        };

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

    private static void HubDataToUpdate(Hub hubFound, HubDto hubDto)
    {
        hubFound.Name = hubDto.Name;
        hubFound.Description = hubDto.Description;
    }

    private static bool CheckUpdateHubData(HubDto hubDto)
    {
        if (hubDto == null) { return false; }

        if (string.IsNullOrEmpty(hubDto.Name)) { return false; }

        if (string.IsNullOrEmpty(hubDto.Description)) { return false; }

        return true;
    }


    #endregion
}
