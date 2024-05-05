using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyLibrary.Application.Dtos.Resume;


namespace MyLibrary.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ResumeController : ControllerBase
{
    #region Fields

    private readonly IMediator _mediator;

    #endregion

    #region Builder

    public ResumeController(IMediator mediator)
    {
        this._mediator = mediator;
    }

    #endregion

    #region Resume

    [HttpGet("{BookId:long}/GetResumeByBookId")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<GetResumeDetailsDto>> GetResumeByBookIdAsync(long BookId)
    {
        throw new NotImplementedException(); 
    }

    [HttpPut("Create")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> CreateAsync()
    {
        throw new NotImplementedException();
    }


    [HttpPut("Update")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> UpdateAsync()
    {
        throw new NotImplementedException();

    }

    [HttpDelete("{ResumeId:long}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> DeleteAsync(long ResumeId)
    {
        throw new NotImplementedException();
    }

    #endregion





}
