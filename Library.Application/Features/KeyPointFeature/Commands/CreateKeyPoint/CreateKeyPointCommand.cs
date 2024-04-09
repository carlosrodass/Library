using CSharpFunctionalExtensions;
using MediatR;
using MyLibrary.Domain.Common;


namespace MyLibrary.Application.Features.KeyPointFeature.Commands.CreateKeyPoint;

public class CreateKeyPointCommand : IRequest<Result<long, Error>>
{
    public long ResumeId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

}
