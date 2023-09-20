using AutoMapper;
using MediatR;
using MyLibrary.Application.Contracts.Persistence;
using MyLibrary.Application.Exceptions;
using MyLibrary.Domain.Models;

namespace MyLibrary.Application.Features.ResumeFeature.Commands.UpdateResume
{
    public class UpdateResumeCommandHandler : IRequestHandler<UpdateResumeCommand, Unit>
    {
        private readonly IResumeRepository _resumeRepository;
        private readonly IMapper _mapper;

        #region Fields


        #endregion

        #region Builder

        public UpdateResumeCommandHandler(IResumeRepository resumeRepository, IMapper mapper)
        {
            _resumeRepository = resumeRepository;
            _mapper = mapper;
        }

        #endregion

        #region public methods

        public async Task<Unit> Handle(UpdateResumeCommand request, CancellationToken cancellationToken)
        {
            var result = await _resumeRepository.GetByIdAsync(request.Id);
            if (result == null) { throw new NotFoundException("Resume", request.Id); }


            await result.Update(request.Title, request.Description, request.Content);

            await _resumeRepository.UpdateAsync(result);
            await _resumeRepository.SaveChangesAsync();
            return new Unit();
        }



        #endregion


        #region Private methods


        #endregion
    }
}
