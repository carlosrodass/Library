using CSharpFunctionalExtensions;
using Moq;
using MyLibrary.Application.Contracts.Persistence;
using MyLibrary.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Application.UnitTests.Mocks
{
    public class MockBookRepository
    {
        public static Mock<IBookRepository> GetBookMockRepository()
        {
            var Books = new List<Book>
            {
                new Book
                {
                    BookId = 1,
                    Title = "Test",
                    AuthorName= "TestAuthor",
                    Isbn = "123456",
                    Price = 10,
                    ReleaseDate = DateTime.Now,
                    Image = null,
                    Order = 1,
                    StatusId = 1,
                    DateCreated= DateTime.Now,
                    DateModified = DateTime.Now,
                    IsDeleted = false,
                    DeletedAt= null
                },
                new Book
                {
                    BookId = 2,
                    Title = "Test2",
                    AuthorName = "TestAuthor2",
                    Isbn = "2",
                    Price = 30,
                    ReleaseDate = DateTime.Now,
                    Image = null,
                    Order = 1,
                    StatusId = 1,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    IsDeleted = false,
                    DeletedAt = null
                },
                 new Book
                {
                    BookId = 3,
                    Title = "Test3",
                    AuthorName = "TestAuthor3",
                    Isbn = "3",
                    Price = 50,
                    ReleaseDate = DateTime.Now,
                    Image = null,
                    Order = 1,
                    StatusId = 1,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    IsDeleted = false,
                    DeletedAt = null
                }
            };

            var mockRepo = new Mock<IBookRepository>();

            mockRepo.Setup(r => r.GetBooksByHubId(1)).ReturnsAsync(Books);

            mockRepo.Setup(r => r.CreateAsync(It.IsAny<Book>()))
                .Returns((Book book) =>
                {
                    Books.Add(book);
                    return Task.CompletedTask;
                });


            return mockRepo;
        }
    }
}
