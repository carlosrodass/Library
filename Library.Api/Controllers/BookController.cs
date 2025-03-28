
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyLibrary.Api.ViewModels.Book;
using MyLibrary.Application.Dtos.Book;
using MyLibrary.Application.Services.Abstract.BookService;

namespace MyLibrary.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;

        public BookController(IBookService bookService, IMapper mapper)
        {
            _bookService = bookService;
            _mapper = mapper;
        }

        [HttpGet()]
        [ProducesResponseType(typeof(List<BookViewModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<BookViewModel>>> GetAllBooksAsync()
         {
            try
            {
                var result = await _bookService.GetAllBooks();
                if (result.IsFailure) { return BadRequest(result); }
                return Ok(_mapper.Map<List<BookViewModel>>(result.Value));
            }
            catch (Exception ex)
            {
                return new List<BookViewModel>();
            }
        }

        [HttpGet("GetAllByHub/{hubId:long}")]
        [ProducesResponseType(typeof(List<BookViewModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<BookViewModel>>> GetAllByHub(long hubId)
        {

            var result = await _bookService.GetAllBooksByHubId(hubId);
            if (result.IsFailure) { return BadRequest(result); }

            return Ok(_mapper.Map<List<BookViewModel>>(result.Value));
        }

        [HttpGet("{bookId:long}")]
        [ProducesResponseType(typeof(BookViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<BookViewModel>> GetByIdAsync(long bookId)
        {

            var result = await _bookService.GetBookByIdAsync(bookId);
            if (result.IsFailure) { return BadRequest(result); }

            return Ok(_mapper.Map<BookViewModel>(result.Value));
        }

        [HttpPost()]
        [ProducesResponseType(typeof(BookViewModel), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> CreateAsync(BookInViewModel bookInViewModel)
        {
            BookDto bookDto = _mapper.Map<BookDto>(bookInViewModel);
            var result = await _bookService.CreateAsync(bookDto);
            if (result.IsFailure) { return BadRequest(result); }

            return Ok(_mapper.Map<BookViewModel>(result.Value));
        }


        [HttpPut()]
        [ProducesResponseType(typeof(BookViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> UpdateAsync(BookUpdateViewModel bookUpdateViewModel)
        {
            BookDto bookDto = _mapper.Map<BookDto>(bookUpdateViewModel);
            var result = await _bookService.UpdateAsync(bookDto);
            if (result.IsFailure) { return BadRequest(result); }

            return Ok(_mapper.Map<BookViewModel>(result.Value));
        }

        [HttpDelete("{bookId:long}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteAsync(long bookId)
        {
            var result = await _bookService.DeleteAsync(bookId);
            if (result.IsFailure) { return BadRequest(result); }

            return Ok(result);
        }

    }
}
