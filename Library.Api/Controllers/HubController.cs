using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyLibrary.Api.ViewModels.Book;
using MyLibrary.Api.ViewModels.Hub;
using MyLibrary.Application.Dtos;
using MyLibrary.Application.Dtos.Book;
using MyLibrary.Application.Services.Abstract.HubService;


namespace MyLibrary.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
//[Authorize]
public class HubController : ControllerBase
{
    private readonly IHubService _hubService;
    private readonly IMapper _mapper;
    public HubController(IHubService hubService, IMapper mapper)
    {

        _hubService = hubService;
        _mapper = mapper;
    }

    [HttpGet("GetAllHubs")]
    [ProducesResponseType(typeof(List<HubViewModel>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<List<HubViewModel>>> GetAllHubsAsync()
    {
        string userId = GetUserClaims();
        var result = await _hubService.GetAllHubsByUserIdAsync(userId);
        if (result.IsFailure) { return BadRequest(result); }

        return Ok(_mapper.Map<List<HubViewModel>>(result.Value));
    }

    [HttpGet("ById/{hubId:long}")]
    [ProducesResponseType(typeof(HubViewModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<HubViewModel>> GetByIdAsync(long hubId)
    {

        string? userId = GetUserClaims();
        var result = await _hubService.GetHubByIdAsync(hubId, userId);
        if (result.IsFailure) { return BadRequest(result); }
        return Ok(_mapper.Map<HubViewModel>(result.Value));
    }


    [HttpPost("CreateAsync")]
    [ProducesResponseType(typeof(HubViewModel), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> CreateAsync(HubInViewModel hubInViewModel)
    {

        string? userId = GetUserClaims();
        HubDto hubDto = _mapper.Map<HubDto>(hubInViewModel);
        hubDto.UserId = userId;
        var result = await _hubService.CreateAsync(hubDto);
        if (result.IsFailure) { return BadRequest(result); }


        return Ok(_mapper.Map<HubViewModel>(result.Value));
    }


    [HttpPut()]
    [ProducesResponseType(typeof(HubViewModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> UpdateAsync(HubUpdateViewModel hubUpdateViewModel)
    {
        var hubDto = _mapper.Map<HubDto>(hubUpdateViewModel);
        var result = await _hubService.UpdateAsync(hubDto);
        if (result.IsFailure) { return BadRequest(result); }

        return Ok(_mapper.Map<HubViewModel>(result.Value));
    }

    [HttpDelete("DeleteAsync/{hubId:long}")]
    [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> DeleteAsync(int hubId)
    {
        try
        {

            var result = await _hubService.DeleteAsync(hubId);
            if (result.IsFailure) { return BadRequest(result); }

            return Ok(result.Value);
        }
        catch (Exception ex)
        {
            return Ok(false);
        }
    }

    [HttpPost("CreateBookFromHub")]
    [ProducesResponseType(typeof(BookViewModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> CreateBookFromHub(BookInViewModel bookInViewModel)
    {
        BookDto bookDto = _mapper.Map<BookDto>(bookInViewModel);
        var result = await _hubService.CreateBookFromHub(bookDto);
        if (result.IsFailure) { return BadRequest(result); }

        return Ok(_mapper.Map<BookViewModel>(result.Value));
        
    }

    [HttpPut("AddBookToHub")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> AddBookToHubAsync(long hubId, long bookId)
    {
        var result = await _hubService.AddBookToHub(hubId, bookId, "e971878c-e3b4-471d-971b-dca461aae708");
        if (result.IsFailure) { return BadRequest(result); }
        return Ok(result);
    }


    #region Private

    //Deberia ser asul
    private string? GetUserClaims()
    {
        var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == "uid");

        return userIdClaim?.Value;

    }

    #endregion
}
