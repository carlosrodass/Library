using AutoMapper;
using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using MyLibrary.Application.Contracts.Persistence;
using MyLibrary.Application.Dtos.Book;
using MyLibrary.Application.Exceptions;
using MyLibrary.Domain.Common;
using MyLibrary.Domain.Models;

namespace MyLibrary.Application.Features.BookFeature.Queries.GetBookDetails;

public class GetBookDetailsQueryHandler : IRequestHandler<GetBookDetailsQuery, Result<GetBookDetailsDto, Error>>
{
    private readonly IMapper _mapper;
    private readonly IBookRepository _bookRepository;

    public GetBookDetailsQueryHandler(IMapper mapper, IBookRepository bookRepository)
    {
        _mapper = mapper;
        _bookRepository = bookRepository;
    }
    public async Task<Result<GetBookDetailsDto, Error>> Handle(GetBookDetailsQuery request, CancellationToken cancellationToken)
    {

        var result = await _bookRepository.GetBookWithDetails(request.BookId);
        if (result is null) { return Error.NotFound; }
        return _mapper.Map<GetBookDetailsDto>(result);

    }
}
