using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyLibrary.Application.Dtos.Resume;
using MyLibrary.Application.Features.BookFeature.Commands.CreateBook;
using MyLibrary.Application.Features.BookFeature.Commands.DeleteBook;
using MyLibrary.Application.Features.BookFeature.Commands.UpdateBook;
using MyLibrary.Application.Features.ResumeFeature.Commands.CreateResume;
using MyLibrary.Application.Features.ResumeFeature.Commands.DeleteResume;
using MyLibrary.Application.Features.ResumeFeature.Commands.UpdateResume;
using MyLibrary.Application.Features.ResumeFeature.Queries.GetAllResumes;
using MyLibrary.Application.Features.ResumeFeature.Queries.GetResumeDetails;

namespace MyLibrary.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
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
        var result = await _mediator.Send(new GetResumeDetailsQuery(BookId));
        if (result.IsFailure) { return BadRequest(result); }

        return Ok(result);
    }

    [HttpPut("Create")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> CreateAsync(CreateResumeCommand createResumeCommand)
    {

        var result = await _mediator.Send(createResumeCommand);
        if (result.IsFailure) { return BadRequest(result); }

        return Ok(result);
    }


    [HttpPut("Update")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> UpdateAsync(UpdateResumeCommand updateResumeCommand)
    {

        var result = await _mediator.Send(updateResumeCommand);
        if (result.IsFailure) { return BadRequest(result); }

        return Ok(result);
    }

    [HttpDelete("{Id:long}/book/{BookId:long}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> DeleteAsync(long Id, long BookId)
    {
        var command = new DeleteResumeCommand { Id = Id, BookId = BookId };
        var result = await _mediator.Send(command);
        if (result.IsFailure) { return BadRequest(result); }
        return NoContent();
    }

    #endregion


    #region KeyPoints

    //[HttpPost("KeyPoint")]
    //[ProducesResponseType(StatusCodes.Status201Created)]
    //[ProducesResponseType(StatusCodes.Status400BadRequest)]
    //[ProducesDefaultResponseType]
    //public async Task<IActionResult> CreateKeyPointAsync(CreateResumeCommand createResumeCommand)
    //{

    //    var result = await _mediator.Send(createResumeCommand);
    //    if (result.IsFailure) { return BadRequest(result); }

    //    return CreatedAtAction(nameof(Get), new { id = result.Value });
    //}


    #endregion




}
