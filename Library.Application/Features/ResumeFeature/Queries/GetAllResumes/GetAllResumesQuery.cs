using CSharpFunctionalExtensions;
using MediatR;
using MyLibrary.Application.Dtos.Resume;
using MyLibrary.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Application.Features.ResumeFeature.Queries.GetAllResumes;

public record GetAllResumesQuery(long BookId) : IRequest<Result<List<GetAllResumesDto>, Error>>;

