using AutoMapper;
using MediatR;
using MyLibrary.Application.Contracts.Persistence;
using MyLibrary.Application.Dtos.Book;

namespace MyLibrary.Application.Features.BookFeature.Queries.GetAllBooks
{
    public class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQuery, List<GetAllBooksDto>>
    {
        private readonly IMapper _mapper;
        private readonly IBookRepository _bookRepository;

        public GetAllBooksQueryHandler(IMapper mapper, IBookRepository bookRepository)
        {
            _mapper = mapper;
            _bookRepository = bookRepository;
        }

        public async Task<List<GetAllBooksDto>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            var booksList = await _bookRepository.GetAsync();
            return _mapper.Map<List<GetAllBooksDto>>(booksList);

        }
    }

}
