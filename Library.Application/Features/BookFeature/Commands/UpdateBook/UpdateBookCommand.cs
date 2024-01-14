using CSharpFunctionalExtensions;
using MediatR;
using MyLibrary.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Application.Features.BookFeature.Commands.UpdateBook
{


    public class UpdateBookCommand : IRequest<Result<long, Error>>
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public string Isbn { get; set; }
        public long Price { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Image { get; set; }
        public int Order { get; set; }
        public int StatusId { get; set; }

    }

}