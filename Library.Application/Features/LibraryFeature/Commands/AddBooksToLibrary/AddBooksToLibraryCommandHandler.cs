using AutoMapper;
using MediatR;
using MyLibrary.Application.Contracts.Persistence;
using MyLibrary.Application.Dtos.Library;
using MyLibrary.Application.Exceptions;
using MyLibrary.Application.Features.BookFeature.Commands.UpdateBook;
using MyLibrary.Domain.Models;

namespace MyLibrary.Application.Features.LibraryFeature.Commands.AddBooksToLibrary
{
    public class AddBooksToLibraryCommandHandler : IRequestHandler<AddBooksToLibraryCommand, GetLibraryDetailsDto>
    {
        #region Fields

        private readonly ILibraryRepository _libraryRepository;
        private IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        #endregion

        #region Builder

        public AddBooksToLibraryCommandHandler(ILibraryRepository libraryRepository,
                                                IBookRepository bookRepository,
                                                IMapper mapper)
        {
            this._libraryRepository = libraryRepository;
            this._bookRepository = bookRepository;
            this._mapper = mapper;
        }

        #endregion

        #region Public method

        public async Task<GetLibraryDetailsDto> Handle(AddBooksToLibraryCommand request, CancellationToken cancellationToken)
        {

            throw new NotImplementedException();

            //var library = await GetLibrary(request.Id);
            //var resultBooks = await CheckAndCreateBooksByIds(request.Books);
            //// library.AddBooks(resultBooks);
            //await _libraryRepository.UpdateAsync(library);
            //await _libraryRepository.SaveChangesAsync();

            //return _mapper.Map<GetLibraryDetailsDto>(library);
        }

        #endregion

        #region Private methods
        // private async Task CreateLibraryBook(int libraryId, List<Book> booksToAddtoLibrary)
        // {
        //     List<LibraryBook> libraryBooks = new List<LibraryBook>();

        //     foreach (var book in booksToAddtoLibrary)
        //     {
        //         LibraryBook libraryBook = new LibraryBook()
        //         {
        //             LibraryId = libraryId,
        //             BookId = book.Id,
        //         };
        //         libraryBooks.Add(libraryBook);
        //     }

        //     await _libraryBookRepository.AddRange(libraryBooks);
        //     await _libraryBookRepository.SaveChangesAsync();
        // }


        //private async Task<List<Book>> CheckAndCreateBooksByIds(List<UpdateBookCommand> books)
        //{
        //    List<Book> booksToAddtoLibrary = new List<Book>();

        //    await CheckBooksWithIds(books.Where(x => x.Id != 0), booksToAddtoLibrary);
        //    await CreateBooksWithoutIds(books.Where(x => x.Id == 0), booksToAddtoLibrary);

        //    return booksToAddtoLibrary;
        //}

        //private async Task CheckBooksWithIds(IEnumerable<UpdateBookCommand> booksWithIds, List<Book> booksToAddtoLibrary)
        //{
        //    var bookIds = booksWithIds.Select(book => book.Id).ToList();

        //    var booksFromRepository = await _bookRepository.GetByIdsAsync(bookIds, includes: null);

        //    var bookDictionary = booksFromRepository.ToDictionary(book => book.Id);

        //    foreach (var bookToCheck in booksWithIds)
        //    {
        //        if (!bookDictionary.TryGetValue(bookToCheck.Id, out Book resultCheckBook))
        //        {
        //            throw new NotFoundException("Book", bookToCheck.Id); //TODO: Add Result Pattern
        //        }

        //        booksToAddtoLibrary.Add(resultCheckBook);
        //    }
        //}

        //private async Task CreateBooksWithoutIds(IEnumerable<UpdateBookCommand> bookWithoutIds, List<Book> booksToAddtoLibrary)
        //{

        //    List<Book> newBooksList = new List<Book>();

        //    foreach (var newBook in bookWithoutIds)
        //    {
        //        var result = Book.Create(newBook.Title, newBook.AuthorName, newBook.Isbn, newBook.Price);
        //        //TODO: Add Result Pattern
        //        newBooksList.Add(result);
        //    }


        //    await _bookRepository.AddRange(newBooksList);
        //    await _bookRepository.SaveChangesAsync();

        //    booksToAddtoLibrary.AddRange(newBooksList);
        //}
        //private async Task<Library> GetLibrary(int id)
        //{
        //    var resultLibrary = await _libraryRepository.GetByIdAsync(id);
        //    if (resultLibrary == null)
        //    {
        //        //TODO: add Result Pattern and return CustomError
        //    }
        //    return resultLibrary;
        //}
        #endregion
    }
}
