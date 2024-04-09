using AutoMapper;
using MyLibrary.Application.Dtos;
using MyLibrary.Application.Dtos.Book;
using MyLibrary.Application.Dtos.Common;
using MyLibrary.Application.Dtos.Hub;
using MyLibrary.Application.Dtos.KeyPoint;
using MyLibrary.Application.Dtos.Resume;
using MyLibrary.Domain.Models;

namespace MyLibrary.Application.MappingProfiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CommonProfile();
        HubProfile();
        BookProfile();
        ResumeProfile();
        KeyPointProfile();
    }
    private void CommonProfile()
    {
        CreateMap<Status, EnumerationDto>();
        CreateMap<ResumeType, EnumerationDto>();
    }

    private void HubProfile()
    {
        CreateMap<Hub, HubDto>();
    }
    private void BookProfile()
    {

        CreateMap<Book, BookDto>();
    }

    private void ResumeProfile()
    {
        CreateMap<Resume, GetResumeDetailsDto>();
        CreateMap<KeyPoint, GetKeyPointDetailsDto>();

    }

    private void KeyPointProfile()
    {
        CreateMap<KeyPoint, GetKeyPointDetailsDto>();
        CreateMap<KeyPoint, GetAllKeyPointsDto>();
    }
}
