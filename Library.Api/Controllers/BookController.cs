
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
        public async Task<IActionResult> Post(CreateBookCommand createBookCommand)
        {

            var result = await _mediator.Send(createBookCommand);
            return CreatedAtAction(nameof(Get), new { id = result });
        }


        [HttpPut()]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Put(UpdateBookCommand updateBookCommand)
        {

            var result = await _mediator.Send(updateBookCommand);
            return Ok(result);
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
