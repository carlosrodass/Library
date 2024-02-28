using AutoMapper;
using CSharpFunctionalExtensions;
using Moq;
using MyLibrary.Application.Contracts.Logging;
using MyLibrary.Application.Contracts.Persistence;
using MyLibrary.Application.Dtos.Book;
using MyLibrary.Application.Features.BookFeature.Queries.GetAllBooks;
using MyLibrary.Application.MappingProfiles;
using MyLibrary.Application.UnitTests.Mocks;
using MyLibrary.Domain.Common;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Application.UnitTests.Features.BookFeature.Queries
{
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
            var handler = new GetAllBooksQueryHandler(_mapper, _mockRepo.Object);

            var result = await handler.Handle(new GetAllBooksQuery(), CancellationToken.None);

            result.ShouldBeOfType<Result<List<GetAllBooksDto>, Error>>();
        }

    }
}
