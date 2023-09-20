using MediatR;
using MyLibrary.Application.Contracts.Persistence;
using MyLibrary.Application.Exceptions;

namespace MyLibrary.Application.Features.ResumeFeature.Commands.DeleteResume
{
    public class DeleteResumeCommandHandler : IRequestHandler<DeleteResumeCommand, Unit>
    {
        private readonly IResumeRepository _resumeRepository;

        public DeleteResumeCommandHandler(IResumeRepository resumeRepository)
        {
            this._resumeRepository = resumeRepository;
        }

        public async Task<Unit> Handle(DeleteResumeCommand request, CancellationToken cancellationToken)
        {

            var resultResume = await _resumeRepository.GetByIdAsync(request.Id);
            if (resultResume == null) { throw new NotFoundException("Resume", request.Id); }

            await _resumeRepository.DeleteAsync(resultResume);
            await _resumeRepository.SaveChangesAsync();

            return new Unit();
        }
    }
}
