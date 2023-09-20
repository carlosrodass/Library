using AutoMapper;
using MediatR;
using MyLibrary.Application.Contracts.Persistence;
using MyLibrary.Application.Dtos.Resume;

namespace MyLibrary.Application.Features.ResumeFeature.Queries.GetAllResumes
{
    public class GetallResumesQueryHandler : IRequestHandler<GetallResumesQuery, List<GetAllResumesDto>>
    {
        private readonly IResumeRepository _resumeRepository;
        private readonly IMapper _mapper;

        public GetallResumesQueryHandler(IResumeRepository resumeRepository, IMapper mapper)
        {
            _resumeRepository = resumeRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAllResumesDto>> Handle(GetallResumesQuery request, CancellationToken cancellationToken)
        {
            var resultResumesList = await _resumeRepository.GetAsync();
            return _mapper.Map<List<GetAllResumesDto>>(resultResumesList);
        }
    }
}
