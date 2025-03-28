using AutoMapper;
using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyLibrary.Api.ViewModels.Book;
using MyLibrary.Api.ViewModels.Resumes;
using MyLibrary.Application.Dtos.Resume;
using MyLibrary.Application.Services.Abstract;


namespace MyLibrary.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
//[Authorize]
public class ResumeController : ControllerBase
{
    #region Fields
    private readonly IResumeService _resumeService;
    private readonly IMapper _mapper;
    #endregion

    #region Builder

    public ResumeController(IResumeService resumeService, IMapper mapper)
    {
        _resumeService = resumeService;
        _mapper = mapper;
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

    [HttpPost("Create")]
    [ProducesResponseType(typeof(ResumesViewModel), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> CreateAsync(ResumesInViewModel resumesInViewModel)
    {
        ResumeDto resumeDto = _mapper.Map<ResumeDto>(resumesInViewModel);
        var result = await _resumeService.CreateResumeAndAssignToBookAsync(resumeDto);
        return Ok(_mapper.Map<ResumesViewModel>(result.Value));

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
