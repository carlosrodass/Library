using CSharpFunctionalExtensions;
using MediatR;
using MyLibrary.Application.Contracts.Persistence;
using MyLibrary.Domain.Common;

namespace MyLibrary.Application.Features.KeyPointFeature.Commands.UpdateKeyPoint
{
    public class UpdateKeyPointCommandHandler : IRequestHandler<UpdateKeyPointCommand, Result<long, Error>>
    {
        private readonly IKeyPointRepository _keyPointRepository;
        private readonly IResumeRepository _resumeRepository;

        public UpdateKeyPointCommandHandler(IKeyPointRepository keyPointRepository, IResumeRepository resumeRepository)
        {
            _keyPointRepository = keyPointRepository;
            _resumeRepository = resumeRepository;
        }

        public async Task<Result<long, Error>> Handle(UpdateKeyPointCommand request, CancellationToken cancellationToken)
        {
            var resume = await _resumeRepository.GetByIdAsync(request.ResumeId);
            if (resume == null) { return Error.NotFound; }

            var keyPoint = await _keyPointRepository.GetByIdAsync(request.KeyPointId);
            if (keyPoint == null) { return Error.NotFound; }

            keyPoint.Name = request.Name;
            keyPoint.Description = request.Description;


            _keyPointRepository.Update(keyPoint);
            await _keyPointRepository.SaveChangesAsync();

            return keyPoint.KeyPointId;
        }
    }
}
