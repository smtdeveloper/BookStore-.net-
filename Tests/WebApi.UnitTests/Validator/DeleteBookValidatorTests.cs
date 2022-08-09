using FluentAssertions;
using TestSetup;
using WebApi.Application.BookOprations;
using WebApi.Validator;
using WebApi.Validator.BookValidator;
using Xunit;

namespace Validator
{
    public class DeleteBookValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Fact]
        public void WhenNotInputAreGiven_Validator_ShoulBeReturnError()
        {
            //Arrenge
           DeleteBook command = new DeleteBook(null);
           command.BookID = 0;
           
           //Arc
           DeleteBookValidator validator = new DeleteBookValidator();
           var result = validator.Validate(command);

           //Assert
            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenInputAreGiven_Validator_ShoulBeReturn()
        {
            //Arrenge
            DeleteBook command = new DeleteBook(null);
            command.BookID = 3;

            //Arc
            DeleteBookValidator validator = new DeleteBookValidator();
            var result = validator.Validate(command);

            //Assert
            result.Errors.Count.Should().Be(0);
            
        }
    }


}