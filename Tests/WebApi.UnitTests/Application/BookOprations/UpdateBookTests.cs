using System;
using System.Linq;
using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.Application.BookOprations;
using WebApi.DbOprations;
using Xunit;

namespace Application.BookOprations
{
    public class UpdateBookTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public UpdateBookTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenBookIdIsGiven_Update_ShoulBeReturn()
        {
            //Arrenge
            UpdateBook command  = new UpdateBook(_context, _mapper);
            command.BookID = 999;

            //Act & Assert (Calıstır & Doğrulama)
            FluentActions
            .Invoking(() => command.Handle())
            .Should().Throw<InvalidOperationException>().And.Message.Should()
            .Be("Kitap Bulunamadı !");
        }

        [Fact]
        public void WhenUpdateModelGiven_Book_Update()
        {
           // Arrenge
            UpdateBook command = new UpdateBook(_context, _mapper);
            UpdateBookModel model = new UpdateBookModel(){Title = "SMTcoder" , GenreID = 1   };
            command.Model = model;
            command.BookID = 2;
            
            // Arc
            FluentActions.Invoking(() => command.Handle()).Invoke();

           //Assert
           var book = _context.Books.SingleOrDefault(book => book.Title == model.Title);
            book.Should().NotBeNull();
            book.GenreId.Should().Be(model.GenreID);

        }

    }
}