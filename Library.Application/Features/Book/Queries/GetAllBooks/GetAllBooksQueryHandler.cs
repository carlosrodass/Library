using AutoMapper;
using Library.Application.Contracts.Persistence;
using Library.Application.Dtos.Book;
using MediatR;

namespace Library.Application.Features.Book.Queries.GetAllBooks
{
    public class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQuery, List<GetAllBooksDto>>
    {
        private readonly IMapper _mapper;
        private readonly IBookRepository _bookRepository;

        public GetAllBooksQueryHandler(IMapper mapper, IBookRepository bookRepository)
        {
            this._mapper = mapper;
            this._bookRepository = bookRepository;
        }

        public async Task<List<GetAllBooksDto>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            var booksList = await _bookRepository.GetAsync();
            return _mapper.Map<List<GetAllBooksDto>>(booksList);

        }
    }

}
