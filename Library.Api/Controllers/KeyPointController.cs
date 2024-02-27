using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyLibrary.Application.Dtos.Book;
using MyLibrary.Application.Dtos.KeyPoint;
using MyLibrary.Application.Features.BookFeature.Queries.GetAllBooks;
using MyLibrary.Application.Features.KeyPointFeature.Commands.CreateKeyPoint;
using MyLibrary.Application.Features.KeyPointFeature.Queries.GetAllKeyPoints;
using MyLibrary.Application.Features.KeyPointFeature.Queries.GetKeyPointDetails;

namespace MyLibrary.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KeyPointController : ControllerBase
    {
        private readonly IMediator _mediator;
        public KeyPointController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<GetAllKeyPointsDto>>> Get()
        {
            var result = await _mediator.Send(new GetAllKeyPointsQuery());
            if (result.IsFailure) { return BadRequest(result); }

            return Ok(result);
        }


        [HttpGet("{KeyPointId:long}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<GetAllKeyPointsDto>>> GetById(long KeyPointId)
        {

            var result = await _mediator.Send(new GetKeyPointDetailsQuery(KeyPointId));
            if (result.IsFailure) { return BadRequest(result); }

            return Ok(result);
        }

        [HttpPost("KeyPoint")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> CreateKeyPointAsync(CreateKeyPointCommand createKeyPointCommand)
        {

            var result = await _mediator.Send(createKeyPointCommand);
            if (result.IsFailure) { return BadRequest(result); }

            return Ok(result);
        }
    }
}
