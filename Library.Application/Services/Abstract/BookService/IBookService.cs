using CSharpFunctionalExtensions;
using MyLibrary.Application.Dtos.Book;
using MyLibrary.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Application.Services.Abstract.BookService
{
    public interface IBookService
    {
        Task<Result<List<BookDto>, Error>> GetAllBooks();
        Task<Result<List<BookDto>, Error>> GetAllBooksByHubId(long hubId);
        Task<Result<BookDto, Error>> GetBookByIdAsync(long bookId);
        Task<Result<BookDto, Error>> CreateAsync(BookDto bookDto);
        Task<Result<BookDto, Error>> UpdateAsync(BookDto bookDto);
        Task<Result<bool, Error>> DeleteAsync(long bookId);
    }
}
