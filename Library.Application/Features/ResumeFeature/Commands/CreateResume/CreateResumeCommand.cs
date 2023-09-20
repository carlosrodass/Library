using MediatR;
using MyLibrary.Application.Dtos.Resume;
using MyLibrary.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Application.Features.ResumeFeature.Commands.CreateResume
{
    public class CreateResumeCommand : IRequest<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public int ResumeTypeId { get; set; }
        public int BookId { get; set; }
    }
}
