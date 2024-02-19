using AutoMapper;
using CSharpFunctionalExtensions;
using MediatR;
using MyLibrary.Application.Contracts.Logging;
using MyLibrary.Application.Contracts.Persistence;
using MyLibrary.Application.Features.BookFeature.Commands.CreateBook;
using MyLibrary.Domain.Common;

namespace MyLibrary.Application.Features.KeyPointFeature.Commands.CreateKeyPoint
{
    public class CreateKeyPointCommandHandler : IRequestHandler<CreateKeyPointCommand, Result<long, Error>>
    {

        #region Fields
        private readonly IMapper _mapper;
        private readonly IBookRepository _bookRepository;
        private readonly IAppLogger<CreateKeyPointCommandHandler> _logger;
        #endregion

        #region Builder

        public CreateKeyPointCommandHandler(IMapper mapper, IBookRepository bookRepository, IAppLogger<CreateKeyPointCommandHandler> logger)
        {
            _mapper = mapper;
            _bookRepository = bookRepository;
            _logger = logger;
        }

        #endregion

        #region KeyPoint


        public async Task<Result<long, Error>> Handle(CreateKeyPointCommand request, CancellationToken cancellationToken)
        {
            //var book = await _bookRepository.GetAsync(x => x.Select(y => y.Resumes.Any(r => r.Id == request.ResumeId)));

            throw new NotImplementedException();
        }


        #endregion
    }

}
