using AutoMapper;
using MyLibrary.Application.Dtos.Book;
using MyLibrary.Application.Dtos.Common;
using MyLibrary.Application.Dtos.Resume;
using MyLibrary.Application.Features.BookFeature.Commands.CreateBook;
using MyLibrary.Application.Features.BookFeature.Commands.UpdateBook;
using MyLibrary.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Application.MappingProfiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CommonProfile();
            BookProfile();
            ResumeProfile();
        }
        private void CommonProfile()
        {
            CreateMap<Status, EnumerationDto>();
            CreateMap<ResumeType, EnumerationDto>();
        }
        private void BookProfile()
        {

            CreateMap<Book, GetAllBooksDto>();
            CreateMap<Book, GetBookDetailsDto>();

            CreateMap<CreateBookCommand, Book>();
            CreateMap<UpdateBookCommand, Book>();
        }

        private void ResumeProfile()
        {
            CreateMap<KeyPoint, GetResumeDetailsDto>();
            CreateMap<KeyPoint, GetAllResumesDto>();

        }
    }
}
