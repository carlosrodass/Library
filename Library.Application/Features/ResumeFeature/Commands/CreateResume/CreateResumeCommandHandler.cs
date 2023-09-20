using AutoMapper;
using MediatR;
using MyLibrary.Application.Contracts.Persistence;
using MyLibrary.Application.Dtos.Resume;
using MyLibrary.Application.Exceptions;
using MyLibrary.Domain.Models;

namespace MyLibrary.Application.Features.ResumeFeature.Commands.CreateResume
{
    public class CreateResumeCommandHandler : IRequestHandler<CreateResumeCommand, int>
    {
        #region Fields

        private readonly IResumeRepository _resumeRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        #endregion

        #region Builder

        public CreateResumeCommandHandler(IResumeRepository resumeRepository, IBookRepository bookRepository, IMapper mapper)
        {
            this._resumeRepository = resumeRepository;
            this._bookRepository = bookRepository;
            this._mapper = mapper;
        }

        #endregion

        #region Public methods

        public async Task<int> Handle(CreateResumeCommand request, CancellationToken cancellationToken)
        {
            await CheckBookExist(request.BookId);
            var newResume = _mapper.Map<Resume>(request);
            await _resumeRepository.CreateAsync(newResume);
            await _resumeRepository.SaveChangesAsync();
            return newResume.Id;
        }

        #endregion


        #region Private methods

        private async Task CheckBookExist(int bookId)
        {
            var book = await _bookRepository.GetByIdAsync(bookId);
            if (book == null) { throw new NotFoundException("Book", bookId); }
        }

        #endregion
    }
}
