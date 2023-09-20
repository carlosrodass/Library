using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Application.Features.ResumeFeature.Commands.DeleteResume
{
    public class DeleteResumeCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
