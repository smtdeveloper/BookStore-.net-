using System;
using System.Linq;
using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.Application.BookOprations;
using WebApi.DbOprations;
using WebApi.Entities;
using Xunit;

namespace Application.BookOprations
{
    public class CreateBookTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateBookTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenAlreadyExistBookTitleIsGiven_InvalidOperationException_ShoulBeReturn()
        {
            //Arrange (Hazırlık)
            var book = new Book() { Title = "Test_WhenAlreadyExistBookTitleIsGiven_InvalidOperationException_ShoulBeReturn", GenreId = 1, PageCount = 100 , IsActive = true, PublishDate = new System.DateTime(1999,06,07)};
            _context.Add(book);
            _context.SaveChanges();

            CreateBook command = new CreateBook(_context,_mapper);
            command.Model = new CreateBookModel() {Title = book.Title};

            //Act & Assert (Calıstır & Doğrulama)
            FluentActions
            .Invoking(() => command.Handle())
            .Should().Throw<InvalidOperationException>().And.Message.Should()
            .Be("Kitap zaten mevcut.");

        }

        [Fact]
        public void WhenValidInputTitleGiven_Book_Created()
        {
            // Arrenge
            CreateBook command = new CreateBook(_context, _mapper);
            CreateBookModel model = new CreateBookModel(){Title = "SMTcoder2" , PageCount = 1000, PublisDate = DateTime.Now.Date.AddYears(-10), GenreId =1 };
            command.Model = model;
            
            // Arc
            FluentActions.Invoking(() => command.Handle()).Invoke();
            
            // Assert
            var book = _context.Books.SingleOrDefault(book => book.Title == model.Title);
            book.Should().NotBeNull();
            book.PageCount.Should().Be(model.PageCount);
            book.GenreId.Should().Be(model.GenreId);
            //book.PublishDate.Should().Be(model.PublisDate);
           

        }
        
        
    }
}