using CSharpFunctionalExtensions;
using MediatR;
using MyLibrary.Domain.Common;
using MyLibrary.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Application.Features.ResumeFeature.Commands.UpdateResume
{
    public class UpdateResumeCommand : IRequest<Result<long, Error>>
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public int ResumeTypeId { get; set; }
        public long BookId { get; set; }

    }
}
