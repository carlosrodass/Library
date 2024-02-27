using AutoMapper;
using CSharpFunctionalExtensions;
using MediatR;
using MyLibrary.Application.Contracts.Persistence;
using MyLibrary.Application.Dtos.Book;
using MyLibrary.Domain.Common;

namespace MyLibrary.Application.Features.BookFeature.Queries.GetAllBooks;

public class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQuery, Result<List<GetAllBooksDto>, Error>>
{
    private readonly IMapper _mapper;
    private readonly IBookRepository _bookRepository;

    public GetAllBooksQueryHandler(IMapper mapper, IBookRepository bookRepository)
    {
        _mapper = mapper;
        _bookRepository = bookRepository;
    }

    public async Task<Result<List<GetAllBooksDto>, Error>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
    {
        var books = await _bookRepository.GetBooksWithDetails();
        if (books.Count > 0)
        {
            return new List<GetAllBooksDto>();
        }

        return _mapper.Map<List<GetAllBooksDto>>(books);

    }
}
