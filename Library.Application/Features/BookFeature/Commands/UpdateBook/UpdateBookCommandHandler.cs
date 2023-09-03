using AutoMapper;
using MediatR;
using MyLibrary.Application.Contracts.Persistence;
using MyLibrary.Domain.Models;

namespace MyLibrary.Application.Features.BookFeature.Commands.UpdateBook
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IBookRepository _bookRepository;

        public UpdateBookCommandHandler(IMapper mapper, IBookRepository bookRepository)
        {
            _mapper = mapper;
            _bookRepository = bookRepository;
        }
        public async Task<int> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            //TODO: Add Validator 
            //TODO: Add exception handler

            var bookToUpdate = _mapper.Map<Book>(request);
            await _bookRepository.UpdateAsync(bookToUpdate);
            await _bookRepository.SaveChangesAsync();
            return bookToUpdate.Id;
        }
    }
}


