using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyLibrary.Application.Dtos.Resume;
using MyLibrary.Application.Features.ResumeFeature.Commands.CreateResume;
using MyLibrary.Application.Features.ResumeFeature.Commands.DeleteResume;
using MyLibrary.Application.Features.ResumeFeature.Commands.UpdateResume;
using MyLibrary.Application.Features.ResumeFeature.Queries.GetAllResumes;
using MyLibrary.Application.Features.ResumeFeature.Queries.GetResumeDetails;

namespace MyLibrary.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResumeController : ControllerBase
    {

        private readonly IMediator _mediator;

        public ResumeController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<GetAllResumesDto>>> Get()
        {
            var result = await _mediator.Send(new GetallResumesQuery());
            return Ok(result);

        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<GetResumeDetailsDto>> Get(int id)
        {
            var result = await _mediator.Send(new GetResumeDetailsQuery(id));
            return Ok(result);
        }

        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Post([FromBody] CreateResumeCommand createResumeCommand)
        {

            var result = await _mediator.Send(createResumeCommand);
            return CreatedAtAction(nameof(Get), new { id = result });
        }


        [HttpPut()]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Put(UpdateResumeCommand updateResumeCommand)
        {
            await _mediator.Send(updateResumeCommand);
            return NoContent();
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteResumeCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
