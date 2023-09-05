using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Application.Features.LibraryFeature.Commands.DeleteLibrary
{
    public class DeleteLibraryCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
