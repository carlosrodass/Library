using CSharpFunctionalExtensions;
using MediatR;
using MyLibrary.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Application.Features.BookFeature.Commands.DeleteBook
{
    public class DeleteBookCommand : IRequest<Result<Unit, Error>>
    {
        public int Id { get; set; }
    }
}
