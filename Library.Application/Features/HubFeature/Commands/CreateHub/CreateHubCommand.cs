using CSharpFunctionalExtensions;
using MediatR;
using MyLibrary.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Application.Features.HubFeature.Commands.CreateHub
{
    public class CreateHubCommand : IRequest<Result<long, Error>>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int StatusId { get; set; }

    }
}
