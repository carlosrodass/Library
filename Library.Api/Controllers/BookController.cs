
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyLibrary.Application.Dtos.Book;
using MyLibrary.Application.Features.BookFeature.Commands.CreateBook;
using MyLibrary.Application.Features.BookFeature.Commands.DeleteBook;
using MyLibrary.Application.Features.BookFeature.Commands.UpdateBook;
using MyLibrary.Application.Features.BookFeature.Queries.GetAllBooks;
using MyLibrary.Application.Features.BookFeature.Queries.GetBookDetails;

namespace MyLibrary.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BookController(IMediator mediator)
        {
            this._mediator = mediator;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<GetAllBooksDto>>> Get()
        {
            var result = await _mediator.Send(new GetAllBooksQuery());
            if (result.IsFailure) { return BadRequest(result); }

            return Ok(result);
        }

        [HttpGet("{id:long}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<GetBookDetailsDto>> GetByIdAsync(int id)
        {
            var result = await _mediator.Send(new GetBookDetailsQuery(id));
            if (result.IsFailure) { return BadRequest(result); }

            return Ok(result);
        }

        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> CreateAsync(CreateBookCommand createBookCommand)
        {

            var result = await _mediator.Send(createBookCommand);
            if (result.IsFailure) { return BadRequest(result); }

            return CreatedAtAction(nameof(Get), new { id = result });
        }


        [HttpPut()]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> UpdateAsync(UpdateBookCommand updateBookCommand)
        {

            var result = await _mediator.Send(updateBookCommand);
            if (result.IsFailure) { return BadRequest(result); }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var command = new DeleteBookCommand { Id = id };
            var result = await _mediator.Send(command);
            if (result.IsFailure) { return BadRequest(result); }
            return NoContent();
        }

    }
}
