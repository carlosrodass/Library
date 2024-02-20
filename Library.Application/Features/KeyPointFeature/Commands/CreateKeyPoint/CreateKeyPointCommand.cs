using CSharpFunctionalExtensions;
using MediatR;
using MyLibrary.Application.Features.BookFeature.Commands.CreateBook;
using MyLibrary.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Application.Features.KeyPointFeature.Commands.CreateKeyPoint
{
    public class CreateKeyPointCommand : IRequest<Result<long, Error>>
    {
        public long BookId { get; set; }
        public long ResumeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }

}
