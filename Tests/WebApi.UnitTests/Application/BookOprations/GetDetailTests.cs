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
    public class GetDetailTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetDetailTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenBookIdIsGiven_GetDetail_ShoulBeReturn()
        {
            //Arrenge
            GetBookDetail query  = new GetBookDetail(_context, _mapper);
            query.BookID = 999;

            //Act & Assert (Calıstır & Doğrulama)
            FluentActions
            .Invoking(() => query.Handle())
            .Should().Throw<InvalidOperationException>().And.Message.Should()
            .Be("Kitap Bulunamadı !");

        }

        [Fact]
        public void WhenValidInputBookIdGiven_Book_GetDetail()
        {
            //Arrenge
            GetBookDetail query  = new GetBookDetail(_context, _mapper);
            BookDetailModel model = new BookDetailModel();
            query.BookID = 1;
             
             // Arc
            FluentActions.Invoking(() => query.Handle()).Invoke();

           //Assert
           var book = _context.Books.SingleOrDefault(book => book.ID == 1);
           book.Should().NotBeNull();


            

        }

    }



}
