using AutoMapper;
using Library.Application.Contracts.Persistence;
using Library.Application.Dtos.Book;
using MediatR;

namespace Library.Application.Features.Book.Queries.GetBookDetails;

public class GetBookDetailsQueryHandler : IRequestHandler<GetBookDetailsQuery, GetBookDetailsDto>
{
    private readonly IMapper _mapper;
    private readonly IBookRepository _bookRepository;

    public GetBookDetailsQueryHandler(IMapper mapper, IBookRepository bookRepository)
    {
        this._mapper = mapper;
        this._bookRepository = bookRepository;
    }
    public async Task<GetBookDetailsDto> Handle(GetBookDetailsQuery request, CancellationToken cancellationToken)
    {

        var result = await _bookRepository.GetByIdAsync(request.id);
        var bookDetailsDto = _mapper.Map<GetBookDetailsDto>(result);
        return bookDetailsDto;
    }
}
