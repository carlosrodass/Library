﻿using CSharpFunctionalExtensions;
using MediatR;

namespace MyLibrary.Application.Features.BookFeature.Commands.CreateBook
{
    public class CreateBookCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public string Isbn { get; set; }
        public long price { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Image { get; set; }
        public int Order { get; set; }
        public int StatusId { get; set; }

    }

}