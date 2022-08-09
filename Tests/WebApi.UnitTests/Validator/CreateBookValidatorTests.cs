using System;
using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.Application.BookOprations;
using WebApi.DbOprations;
using WebApi.Entities;
using WebApi.Validator;
using WebApi.Validator.BookValidator;
using Xunit;

namespace Validator
{
    public class CreateBookValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory] // Theory :birdan fazla calıstırmak için.
        [InlineData("SMTcoder",0,0)]
        [InlineData("SMTcoder",0,1)]
        [InlineData("SMTcoder",100,0)]
        [InlineData(" ",100,0)]
        [InlineData("S",100,0)]
        [InlineData("S",100,1)]
        [InlineData("S",0,0)]
        [InlineData("SMTc",100,0)]
        [InlineData("SMTc",0,1)]
        public void WhenInvalidInputsAreGiven_Validator_ShoulBeReturnErrors(string title,int pageCount , int genreId)
        {
            //Arrange
            CreateBook command = new CreateBook(null,null);
            command.Model = new CreateBookModel()
            {
                Title = title,
                PageCount = pageCount,
                GenreId = genreId,
                PublisDate = DateTime.Now.Date.AddYears(-1)
            };
            
            //Arc
            CreateBookValidator validator = new CreateBookValidator();
            var result = validator.Validate(command);
            
            //Assert
            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenDateTimeNowIsGiven_Validator_ShoulBeReturnError()
        {
            // Arrenge
             CreateBook command = new CreateBook(null,null);
             command.Model = new CreateBookModel()
            {
                Title = "SMTcoder",
                PageCount = 100,
                GenreId = 1,
                PublisDate = DateTime.Now.Date
            };
            // Arc
            CreateBookValidator validator = new CreateBookValidator();
            var result = validator.Validate(command);

            // Assert
            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenValidInoutsAreGiven_Validator_ShouldNotBeReturnError()
        {
            // Arrenge
            CreateBook commnad = new CreateBook(null,null);
            commnad.Model = new CreateBookModel()
            {
                Title = "SMTcoder",
                PageCount = 100,
                GenreId = 1,
                PublisDate = DateTime.Now.Date.AddYears(-2)
            };

            //Arc
            CreateBookValidator validator = new CreateBookValidator();
            var  result = validator.Validate(commnad);

            //Assert
            result.Errors.Count.Should().Equals(0);
            
        }
        
        
    }
}