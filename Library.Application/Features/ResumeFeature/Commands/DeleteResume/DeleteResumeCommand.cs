using CSharpFunctionalExtensions;
using MediatR;
using MyLibrary.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Application.Features.ResumeFeature.Commands.DeleteResume;

public class DeleteResumeCommand : IRequest<Result<Unit, Error>>
{
    public long ResumeId { get; set; }
}
