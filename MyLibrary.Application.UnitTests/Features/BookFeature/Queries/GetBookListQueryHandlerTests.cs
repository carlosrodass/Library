using AutoMapper;
using CSharpFunctionalExtensions;
using Moq;
using MyLibrary.Application.Contracts.Persistence;
using MyLibrary.Application.UnitTests.Mocks;
using MyLibrary.Domain.Common;
using Shouldly;

namespace MyLibrary.Application.UnitTests.Features.BookFeature.Queries;

public class GetBookListQueryHandlerTests
{
    private readonly Mock<IBookRepository> _mockRepo;
    private IMapper _mapper;


    public GetBookListQueryHandlerTests()
    {
        _mockRepo = MockBookRepository.GetBookMockRepository();

        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<MyLibrary.Application.MappingProfiles.MappingProfiles>();
        });

        _mapper = mapperConfig.CreateMapper();

    }

    [Fact]
    public async Task GetAllBooksTest()
    {
        //var handler = new GetAllBooksQueryHandler(_mapper, _mockRepo.Object);

        //var result = await handler.Handle(new GetAllBooksQuery(), CancellationToken.None);

        //result.ShouldBeOfType<Result<List<GetAllBooksDto>, Error>>();
        throw new NotImplementedException();
    }

}
