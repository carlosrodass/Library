using AutoMapper;
using Library.Application.Contracts.Persistence;
using MediatR;

namespace Library.Application.Features.Book.Commands.CreateBook
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IBookRepository _bookRepository;

        public CreateBookCommandHandler(IMapper mapper, IBookRepository bookRepository)
        {
            this._mapper = mapper;
            this._bookRepository = bookRepository;
        }
        public async Task<int> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            //TODO: Add Validator 
            //TODO: Add exception handler

            var bookToCreate = _mapper.Map<Library.Domain.Book>(request);
            await _bookRepository.CreateAsync(bookToCreate);
            return bookToCreate.Id;
        }
    }

}
