using AutoMapper;
using Library.Application.Contracts.Persistence;
using MediatR;

namespace Library.Application.Features.Book.Commands.UpdateBook
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IBookRepository _bookRepository;

        public UpdateBookCommandHandler(IMapper mapper, IBookRepository bookRepository)
        {
            this._mapper = mapper;
            this._bookRepository = bookRepository;
        }
        public async Task<int> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            //TODO: Add Validator 
            //TODO: Add exception handler

            var bookToUpdate = _mapper.Map<Library.Domain.Book>(request);
            await _bookRepository.UpdateAsync(bookToUpdate);
            return bookToUpdate.Id;
        }
    }
}
