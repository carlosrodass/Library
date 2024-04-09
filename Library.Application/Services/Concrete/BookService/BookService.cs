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
    private readonly IMapper _mapper;
    private readonly IBookRepository _bookRepository;


    #region Builder

    public BookService(IMapper mapper, IBookRepository bookRepository)
    {
        _mapper = mapper;
        _bookRepository = bookRepository;
    }

    #endregion


    #region Public methods

    public async Task<Result<BookDto, Error>> GetBookByIdAsync(long id)
    {
        var result = await _bookRepository.GetByIdAsync(id);
        if (result == null) { return Error.NotFound; }
        return _mapper.Map<BookDto>(result);
    }
    public async Task<Result<List<BookDto>, Error>> GetAllBooksByHubId(long hubId)
    {
        var results = await _bookRepository.GetBooksByHubId(hubId);
        if (results == null) { return Error.NotFound; }

        return _mapper.Map<List<BookDto>>(results);
    }
    public async Task<Result<BookDto, Error>> CreateAsync(BookDto bookDto)
    {
        Book book = new()
        {
            Title = bookDto.Title,
            AuthorName = bookDto.AuthorName,
            Isbn = bookDto.Isbn,
            Price = bookDto.Price,
            ReleaseDate = bookDto.ReleaseDate,
            Image = bookDto.Image,
            Order = bookDto.Order,
            StatusId = bookDto.StatusId,
        };

        await _bookRepository.CreateAsync(book);
        await _bookRepository.SaveChangesAsync();

        return _mapper.Map<BookDto>(book);
    }
    public async Task<Result<BookDto, Error>> UpdateAsync(BookDto bookDto)
    {
        throw new NotImplementedException();
    }
    public async Task<Result<bool, Error>> DeleteAsync(long bookId)
    {
        throw new NotImplementedException();
    }

    #endregion


    #region Private

    private string RemoveLetters(string input)
    {
        //string result = "";  

        //foreach (char c in input)
        //{
        //    if (!char.IsLetter(c))
        //    {
        //        result += c;
        //    }
        //}

        return new string(input.Where(c => !char.IsLetter(c)).ToArray());

        //return result;
    }

    #endregion
}
