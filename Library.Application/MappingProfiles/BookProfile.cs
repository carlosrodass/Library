using AutoMapper;
using Library.Application.Dtos.Book;
using Library.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.MappingProfiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book, GetAllBooksDto>();
            CreateMap<Book, GetBookDetailsDto>();
        }

    }
}
