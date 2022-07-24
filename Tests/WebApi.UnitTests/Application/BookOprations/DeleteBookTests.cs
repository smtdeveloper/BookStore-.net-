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
    public class DeleteBookTests: IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
       

        public DeleteBookTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [Fact]
        public void WhenAlreadyExistBookIdIsGiven_InvalidOperationException_ShoulBeReturn()
        {
            //Arrenge
            DeleteBook command  = new DeleteBook(_context);
            command.BookID = 999;

            //Act & Assert (Calıstır & Doğrulama)
            FluentActions
            .Invoking(() => command.Handle())
            .Should().Throw<InvalidOperationException>().And.Message.Should()
            .Be("Kitap Bulunamadı !");
        }

        [Fact]
        public void WhenValidInputIdGiven_Book_Deleted()
        {
           //Arrenge
            var book = new Book() {  Title = "DeleteBook", GenreId = 1, PageCount = 100 , IsActive = true, PublishDate = new System.DateTime(1999,06,07) };
            _context.Add(book);
            _context.SaveChanges();
            
            DeleteBook command  = new DeleteBook(_context);
            command.BookID = book.ID;

            //Act
           FluentActions.Invoking(() => command.Handle()).Invoke();

           //Assert
            book = _context.Books.SingleOrDefault(x => x.ID == book.ID);
            book.Should().BeNull();
           

           //book.ID.Should().Be(book.ID);
        }
    }
}