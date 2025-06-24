using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyLibrary.Application.Dtos.KeyPoint;

namespace MyLibrary.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class KeyPointController : ControllerBase
{
    
    public KeyPointController()
    {
        
    }

    [HttpGet()]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<List<GetAllKeyPointsDto>>> Get()
    {
        throw new NotImplementedException();
    }


    [HttpGet("{KeyPointId:long}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<List<GetAllKeyPointsDto>>> GetById(long KeyPointId)
    {

        throw new NotImplementedException();
    }

    [HttpPost("KeyPoint")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> CreateKeyPointAsync()
    {

        throw new NotImplementedException();
    }
}
