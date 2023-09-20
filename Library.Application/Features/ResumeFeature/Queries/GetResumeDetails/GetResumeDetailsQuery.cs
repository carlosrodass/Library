using MediatR;
using MyLibrary.Application.Dtos.Resume;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Application.Features.ResumeFeature.Queries.GetResumeDetails
{
    public record GetResumeDetailsQuery(int Id) : IRequest<GetResumeDetailsDto>;
}
