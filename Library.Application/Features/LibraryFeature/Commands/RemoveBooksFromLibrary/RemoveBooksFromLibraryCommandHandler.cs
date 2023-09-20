using AutoMapper;
using MediatR;
using MyLibrary.Application.Contracts.Persistence;
using MyLibrary.Application.Dtos.Library;
using MyLibrary.Application.Exceptions;
using MyLibrary.Domain.Models;

namespace MyLibrary.Application.Features.LibraryFeature.Commands.RemoveBooksFromLibrary
{
    public class RemoveBooksFromLibraryCommandHandler : IRequestHandler<RemoveBooksFromLibraryCommand, GetLibraryDetailsDto>
    {
        #region Fields
        private readonly ILibraryRepository _libraryRepository;
        private readonly ILibraryBookRepository _libraryBookRepository;
        private readonly IMapper _mapper;

        #endregion

        #region Builder

        public RemoveBooksFromLibraryCommandHandler(ILibraryRepository libraryRepository,
                                                    ILibraryBookRepository libraryBookRepository,
                                                    IMapper mapper)
        {
            this._libraryRepository = libraryRepository;
            this._libraryBookRepository = libraryBookRepository;
            this._mapper = mapper;
        }
        #endregion

        #region Public method

        public async Task<GetLibraryDetailsDto> Handle(RemoveBooksFromLibraryCommand request, CancellationToken cancellationToken)
        {
            var resultLibrary = await GetLibrary(request.Id);
            await CheckBooks(request.BooksIds);



            return _mapper.Map<GetLibraryDetailsDto>(resultLibrary);
        }

        #endregion

        #region Private methods

        private async Task<Library> GetLibrary(int id)
        {
            var resultLibrary = await _libraryRepository.GetByIdAsync(id);
            if (resultLibrary == null) { throw new NotFoundException("Library", id); }
            return resultLibrary;
        }
        private async Task CheckBooks(List<int> booksIds)
        {
            ///ADD FILTER TO GET ASYNC METHOD

            //_libraryBookRepository.GetAsync();

            throw new NotImplementedException();
        }


        #endregion


    }
}
