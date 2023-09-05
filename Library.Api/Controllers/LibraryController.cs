using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyLibrary.Application.Dtos.Library;
using MyLibrary.Application.Features.LibraryFeature.Commands.AddBooksToLibrary;
using MyLibrary.Application.Features.LibraryFeature.Commands.CreateLibrary;
using MyLibrary.Application.Features.LibraryFeature.Commands.DeleteLibrary;
using MyLibrary.Application.Features.LibraryFeature.Commands.UpdateLibrary;
using MyLibrary.Application.Features.LibraryFeature.Queries.GetAllLibraries;
using MyLibrary.Application.Features.LibraryFeature.Queries.GetLibraryDetails;

namespace MyLibrary.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LibraryController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<GetAllLibrariesDto>>> Get()
        {
            var result = await _mediator.Send(new GetAllLibrariesQuery());
            return Ok(result);

        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<GetLibraryDetailsDto>> Get(int id)
        {
            var result = await _mediator.Send(new GetLibraryDetailsQuery(id));
            return Ok(result);
        }


        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Post([FromBody] CreateLibraryCommand createLibraryCommand)
        {

            var result = await _mediator.Send(createLibraryCommand);
            return CreatedAtAction(nameof(Get), new { id = result });
        }


        [HttpPut()]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Put(UpdateLibraryCommand updateLibraryCommand)
        {
            await _mediator.Send(updateLibraryCommand);
            return NoContent();
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteLibraryCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpPost("AddBooks")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<GetLibraryDetailsDto>> AddBooks([FromBody] AddBooksToLibraryCommand addBooksToLibraryCommand)
        {

            var result = await _mediator.Send(addBooksToLibraryCommand);
            return Ok(result);
        }

    }
}
