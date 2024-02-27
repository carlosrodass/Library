using AutoMapper;
using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using MyLibrary.Application.Contracts.Logging;
using MyLibrary.Application.Contracts.Persistence;
using MyLibrary.Application.Features.BookFeature.Commands.CreateBook;
using MyLibrary.Domain.Common;
using MyLibrary.Domain.Models;
using System.Security.Cryptography.X509Certificates;

namespace MyLibrary.Application.Features.KeyPointFeature.Commands.CreateKeyPoint
{
    public class CreateKeyPointCommandHandler : IRequestHandler<CreateKeyPointCommand, Result<long, Error>>
    {

        #region Fields
        private readonly IMapper _mapper;
        private readonly IResumeRepository _resumeRepository;
        private readonly IKeyPointRepository _keyPointRepository;
        private readonly IAppLogger<CreateKeyPointCommandHandler> _logger;
        #endregion

        #region Builder

        public CreateKeyPointCommandHandler(IMapper mapper, IAppLogger<CreateKeyPointCommandHandler> logger, IResumeRepository resumeRepository, IKeyPointRepository keyPointRepository)
        {
            _mapper = mapper;
            _logger = logger;
            _resumeRepository = resumeRepository;
            _keyPointRepository = keyPointRepository;
        }

        #endregion

        #region KeyPoint

        public async Task<Result<long, Error>> Handle(CreateKeyPointCommand request, CancellationToken cancellationToken)
        {

            var resume = await _resumeRepository.GetResumeWithDetails(request.ResumeId);
            if (resume is null) { return Error.NotFound; }


            KeyPoint keyPoint = new KeyPoint()
            {
                Name = request.Name,
                Description = request.Description,
                ResumeId = request.ResumeId,
            };

            resume.KeyPoints.Add(keyPoint);

            await _keyPointRepository.CreateAsync(keyPoint);
            await _keyPointRepository.SaveChangesAsync();

            _resumeRepository.Update(resume);
            await _resumeRepository.SaveChangesAsync();

            return resume.ResumeId;
        }


        #endregion


        #region Private methods

        #endregion

    }

}
