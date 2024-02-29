using CSharpFunctionalExtensions;
using MediatR;
using MyLibrary.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Application.Features.HubFeature.Commands.AddBookToHub
{
    public class AddBookToHubCommand : IRequest<Result<long, Error>>
    {
        public long HubId { get; set; }
        public long BookId { get; set; }
    }
}
