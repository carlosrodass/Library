using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using MyLibrary.Application.Contracts.Persistence;
using MyLibrary.Application.Dtos.Resume;
using MyLibrary.Application.Exceptions;
using MyLibrary.Domain.Models;

namespace MyLibrary.Application.Features.ResumeFeature.Queries.GetResumeDetails
{
    public class GetResumeDetailsQueryHandler : IRequestHandler<GetResumeDetailsQuery, GetResumeDetailsDto>
    {

        private readonly IResumeRepository _resumeRepository;
        private readonly IMapper _mapper;




        public GetResumeDetailsQueryHandler(IResumeRepository resumeRepository, IMapper mapper)
        {
            _resumeRepository = resumeRepository;
            _mapper = mapper;
        }




        public async Task<GetResumeDetailsDto> Handle(GetResumeDetailsQuery request, CancellationToken cancellationToken)
        {
            var resumeResult = await _resumeRepository.GetByIdAsync(request.Id, GetIncludes());
            if (resumeResult == null) { throw new NotFoundException("Resume", request.Id); }

            return _mapper.Map<GetResumeDetailsDto>(resumeResult);

        }

        private Func<IQueryable<Resume>, IIncludableQueryable<Resume, object>> GetIncludes()
        {
            return includes => includes
                .Include(r => r.ResumeType)
                .Include(r => r.Book);
        }


    }
}
