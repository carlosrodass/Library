using AutoMapper;
using MyLibrary.Api.ViewModels.Book;
using MyLibrary.Api.ViewModels.Common;
using MyLibrary.Api.ViewModels.Hub;
using MyLibrary.Api.ViewModels.Resumes;
using MyLibrary.Application.Dtos;
using MyLibrary.Application.Dtos.Book;
using MyLibrary.Application.Dtos.Common;
using MyLibrary.Application.Dtos.Resume;
using MyLibrary.Domain.Models;

namespace MyLibrary.Api.Mapping;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CommonProfile();
        HubProfile();
        BookProfile();
        ResumesProfile();
    }


    private void CommonProfile()
    {
        CreateMap<EnumerationDto, EnumerationViewModel>();
    }
    private void HubProfile()
    {
        CreateMap<HubInViewModel, HubDto>();
        CreateMap<HubUpdateViewModel, HubDto>();
        CreateMap<HubDto, HubViewModel>();
    }

    private void BookProfile()
    {
        CreateMap<BookInViewModel, BookDto>();
        CreateMap<BookUpdateViewModel, BookDto>();
        CreateMap<BookDto, BookViewModel>();
    }

    private void ResumesProfile()
    {
        CreateMap<ResumesInViewModel, ResumeDto>();
        CreateMap<ResumesUpdateViewModel, ResumeDto>();
        CreateMap<ResumeDto, ResumesViewModel>();
    }
}
