using AutoMapper;
using CSharpFunctionalExtensions;
using MediatR;
using MyLibrary.Application.Contracts.Persistence;
using MyLibrary.Application.Dtos.Book;
using MyLibrary.Application.Services.Abstract.BookService;
using MyLibrary.Domain.Common;
using MyLibrary.Domain.Models;


namespace MyLibrary.Application.Services.Concrete.BookService;

internal sealed class BookService : IBookService
{
    #region Fields
    private readonly IMapper _mapper;
    private readonly IBookRepository _bookRepository;
    #endregion

    #region Builder
    public BookService(IMapper mapper, IBookRepository bookRepository)
    {
        _mapper = mapper;
        _bookRepository = bookRepository;
    }
    #endregion

    #region Public methods
    public async Task<Result<List<BookDto>, Error>> GetAllBooks()
    {
        var result = await _bookRepository.GetAsync();
        if (result == null) { return Error.NotFound; }

        return _mapper.Map<List<BookDto>>(result);
    }
    public async Task<Result<BookDto, Error>> GetBookByIdAsync(long id)
    {
        var result = await GetBookById(id);
        if (result.IsFailure) { return result.Error; }

        return _mapper.Map<BookDto>(result.Value);
    }
    public async Task<Result<List<BookDto>, Error>> GetAllBooksByHubId(long hubId)
    {
        var results = await _bookRepository.GetBooksByHubId(hubId);
        if (results == null) { return Error.NotFound; }

        return _mapper.Map<List<BookDto>>(results);
    }
    public async Task<Result<BookDto, Error>> CreateAsync(BookDto bookDto)
    {
        Book book = new();
        book.Initialize(
            bookDto.Title,
            bookDto.AuthorName,
            bookDto.Isbn,
            bookDto.Price,
            bookDto.ReleaseDate,
            bookDto.Image,
            bookDto.Order,
            bookDto.StatusId
        );

        await _bookRepository.CreateAsync(book);
        await _bookRepository.SaveChangesAsync();

        return _mapper.Map<BookDto>(book);
    }
    public async Task<Result<BookDto, Error>> UpdateAsync(BookDto bookDto)
    {
        var resultBook = await GetBookById(bookDto.BookId);

        if (resultBook.IsFailure) { return resultBook.Error; }

        var isValidData = CheckBookDataToUpdate(bookDto);
        if (isValidData.IsFailure) { return isValidData.Error; }

        resultBook = resultBook.Value.Update(bookDto.Title, bookDto.AuthorName);

        _bookRepository.Update(resultBook.Value);
        await _bookRepository.SaveChangesAsync();

        return _mapper.Map<BookDto>(resultBook.Value);
    }
    public async Task<Result<bool, Error>> DeleteAsync(long bookId)
    {
        throw new NotImplementedException();
    }

    #endregion

    #region Private

    private async Task<Result<Book, Error>> GetBookById(long id)
    {
        var result = await _bookRepository.GetByIdAsync(id);
        if (result == null) { return Error.NotFound; }
        return result;
    }

    private Result<bool, Error> CheckBookDataToUpdate(BookDto bookDto)
    {
        if (bookDto == null) { return CustomErrors.Book.NotFound(); }

        if (string.IsNullOrEmpty(bookDto.Title)) { return CustomErrors.Book.NotValid(); }

        if (string.IsNullOrEmpty(bookDto.AuthorName)) { return CustomErrors.Book.NotValid(); }

        return true;
    }




    #endregion
}
