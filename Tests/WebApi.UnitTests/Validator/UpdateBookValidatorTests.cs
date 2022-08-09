using FluentAssertions;
using TestSetup;
using WebApi.Application.BookOprations;
using WebApi.Validator;
using WebApi.Validator.BookValidator;
using Xunit;

namespace Validator 
{
    public class UpdateBookValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData("SMTcoder", 0)]
        [InlineData("SMT", 1)]
        [InlineData("SMTs", 0)]
        [InlineData(" ", 0)]
        [InlineData(" ", 1)]
        public void WhenInputsGiven_Validator_ShoulBeReturnErrors(string title, int genreId)
        {
            //Arrenge
            UpdateBook command = new UpdateBook(null,null);
            command.Model = new UpdateBookModel()
            {
                Title = title,
                GenreID = genreId,
            };
            
            //Arc
            UpdateBookValidator validator = new UpdateBookValidator();
            var result = validator.Validate(command);
            
            //Assert
            result.Errors.Count.Should().BeGreaterThan(0);

        }

        [Fact]
        public void WhenInputAreGiven_Validator_ShoulBeReturn()
        {
            // Arrenge
            UpdateBook commnad = new UpdateBook(null,null);
            commnad.Model = new UpdateBookModel()
            {
                Title = "SMTcoder",
                GenreID = 1
            };

            //Arc
            UpdateBookValidator validator = new UpdateBookValidator();
            var  result = validator.Validate(commnad);

            //Assert
            result.Errors.Count.Should().Equals(0);
        }
    }
}