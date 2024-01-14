using CSharpFunctionalExtensions;
using MediatR;
using MyLibrary.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Application.Features.ResumeFeature.Commands.CreateResume
{
    public class CreateResumeCommand : IRequest<Result<long, Error>>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public int ResumeTypeId { get; set; }
        public long BookId { get; set; }

    }
}
