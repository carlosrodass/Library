using CSharpFunctionalExtensions;
using MediatR;
using MyLibrary.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Application.Features.LibraryFeature.Commands.DeleteLibrary
{
    public class DeleteLibraryCommand : IRequest<Result<Unit, Error>>
    {
        public int Id { get; set; }
    }
}
