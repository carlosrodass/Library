using Library.Application.Dtos.Book;
using Library.Application.Features.Book.Commands.CreateBook;
using Library.Application.Features.Book.Commands.DeleteBook;
using Library.Application.Features.Book.Commands.UpdateBook;
using Library.Application.Features.Book.Queries.GetAllBooks;
using Library.Application.Features.Book.Queries.GetBookDetails;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers
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
            return Ok(result);

        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<GetBookDetailsDto>> Get(int id)
        {
            var result = await _mediator.Send(new GetBookDetailsQuery(id));
            return Ok(result);
        }

        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Post([FromBody] CreateBookCommand createBookCommand)
        {

            var result = await _mediator.Send(createBookCommand);
            return CreatedAtAction(nameof(Get), new { id = result });
        }


        [HttpPut()]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Put(UpdateBookCommand updateBookCommand)
        {
            await _mediator.Send(updateBookCommand);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteBookCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }

    }
}
