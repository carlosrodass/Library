using CSharpFunctionalExtensions;
using MediatR;
using MyLibrary.Domain.Common;

namespace MyLibrary.Application.Features.BookFeature.Commands.CreateBook
{
    public class CreateBookCommand : IRequest<Result<long, Error>>
    {
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
