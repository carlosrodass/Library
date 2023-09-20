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
        private ILibraryBookRepository _libraryBookRepository;
        private IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        #endregion

        #region Builder

        public AddBooksToLibraryCommandHandler(ILibraryRepository libraryRepository,
                                                ILibraryBookRepository libraryBookRepository,
                                                IBookRepository bookRepository,
                                                IMapper mapper)
        {
            this._libraryRepository = libraryRepository;
            this._libraryBookRepository = libraryBookRepository;
            this._bookRepository = bookRepository;
            this._mapper = mapper;
        }

        #endregion

        #region Public method

        public async Task<GetLibraryDetailsDto> Handle(AddBooksToLibraryCommand request, CancellationToken cancellationToken)
        {

            var resultLibrary = await GetLibrary(request.Id);

            List<Book> booksToAddtoLibrary = new List<Book>();

            await CheckAndCreateBooksByIds(request.Books, booksToAddtoLibrary);
            await CreateLibraryBook(request.Id, booksToAddtoLibrary);

            await _libraryRepository.UpdateAsync(resultLibrary);
            await _libraryRepository.SaveChangesAsync();

            return _mapper.Map<GetLibraryDetailsDto>(resultLibrary);
        }

        #endregion

        #region Private methods
        private async Task CreateLibraryBook(int libraryId, List<Book> booksToAddtoLibrary)
        {
            List<LibraryBook> libraryBooks = new List<LibraryBook>();

            foreach (var book in booksToAddtoLibrary)
            {
                LibraryBook libraryBook = new LibraryBook()
                {
                    LibraryId = libraryId,
                    BookId = book.Id,
                };
                libraryBooks.Add(libraryBook);
            }

            await _libraryBookRepository.AddRange(libraryBooks);
            await _libraryBookRepository.SaveChangesAsync();
        }
        private async Task CheckAndCreateBooksByIds(List<UpdateBookCommand> books, List<Book> booksToAddtoLibrary)
        {
            var booksWithIds = books.Where(x => x.Id != 0);
            var bookWithoutIds = books.Where(x => x.Id == 0);

            await CheckBooksWithIds(booksWithIds, booksToAddtoLibrary);
            await CreateBooksWithoutIds(bookWithoutIds, booksToAddtoLibrary);
        }
        private async Task CheckBooksWithIds(IEnumerable<UpdateBookCommand> booksWithIds, List<Book> booksToAddtoLibrary)
        {

            foreach (var bookToCheck in booksWithIds)
            {
                var resultCheckBook = await _bookRepository.GetByIdAsync(bookToCheck.Id);
                if (resultCheckBook == null) { throw new NotFoundException("Book", bookToCheck.Id); }
                booksToAddtoLibrary.Add(resultCheckBook);
            }
        }
        private async Task CreateBooksWithoutIds(IEnumerable<UpdateBookCommand> bookWithoutIds, List<Book> booksToAddtoLibrary)
        {
            var booksToCreate = _mapper.Map<List<Book>>(bookWithoutIds);
            await _bookRepository.AddRange(booksToCreate);
            await _bookRepository.SaveChangesAsync();

            booksToAddtoLibrary.AddRange(booksToCreate);
        }
        private async Task<Library> GetLibrary(int id)
        {
            var resultLibrary = await _libraryRepository.GetByIdAsync(id);
            if (resultLibrary == null) { throw new NotFoundException("Library", id); }
            return resultLibrary;
        }
        #endregion
    }
}
