using CSharpFunctionalExtensions;
using MediatR;
using MyLibrary.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Application.Features.KeyPointFeature.Commands.UpdateKeyPoint
{
    public class UpdateKeyPointCommand : IRequest<Result<long, Error>>
    {
        public long KeyPointId { get; set; }
        public long ResumeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
