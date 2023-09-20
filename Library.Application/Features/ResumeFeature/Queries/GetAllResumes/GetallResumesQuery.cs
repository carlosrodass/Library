using MediatR;
using MyLibrary.Application.Dtos.Resume;
using MyLibrary.Application.Features.BookFeature.Queries.GetAllBooks;

namespace MyLibrary.Application.Features.ResumeFeature.Queries.GetAllResumes
{
    public record GetallResumesQuery : IRequest<List<GetAllResumesDto>>;
}
