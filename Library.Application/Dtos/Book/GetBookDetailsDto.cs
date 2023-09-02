﻿using Library.Domain;

namespace Library.Application.Dtos.Book
{
    public class GetBookDetailsDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public string Isbn { get; set; }
        public long price { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Image { get; set; }
        public int Order { get; set; }
        //public IEnumerable<ResumeDto> Resumes { get; set; }
        //public StatusDto Status { get; set; }
    }

}