using AutoMapper;
using MyLibrary.Application.Dtos.Book;
using MyLibrary.Application.Dtos.Common;
using MyLibrary.Application.Dtos.Library;
using MyLibrary.Application.Dtos.LibraryBook;
using MyLibrary.Application.Dtos.Resume;
using MyLibrary.Application.Features.BookFeature.Commands.CreateBook;
using MyLibrary.Application.Features.BookFeature.Commands.UpdateBook;
using MyLibrary.Application.Features.LibraryFeature.Commands.CreateLibrary;
using MyLibrary.Application.Features.LibraryFeature.Commands.UpdateLibrary;
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
            LibraryProfile();
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
        private void LibraryProfile()
        {
            CreateMap<Library, GetLibraryDetailsDto>();
            CreateMap<Library, GetAllLibrariesDto>();

            CreateMap<CreateLibraryCommand, Library>();
            CreateMap<UpdateLibraryCommand, Library>();

            CreateMap<LibraryBook, LibraryBookDto>();
        }
        private void ResumeProfile()
        {
            CreateMap<Resume, GetResumeDetailsDto>();
            CreateMap<Resume, GetAllResumesDto>();

        }
    }
}
