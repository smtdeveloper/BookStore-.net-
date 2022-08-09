using FluentAssertions;
using TestSetup;
using WebApi.Application.BookOprations;
using WebApi.Validator;
using WebApi.Validator.BookValidator;
using Xunit;

namespace Validator 
{
    public class GetBookDetailValidatorTest : IClassFixture<CommonTestFixture>
    {
        [Fact]
        public void WhenNotInputAreGiven_Validator_ShoulBeReturnError()
        {
            //Arrenge
            GetBookDetail query = new GetBookDetail(null,null);
            query.BookID = 0;

            //Arc
            GetBookDetailValidator validator = new GetBookDetailValidator();
            var result = validator.Validate(query);

            //Assert
            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenInputAreGiven_Validator_ShoulBeReturn()
        {
            //Arrenge
            GetBookDetail query = new GetBookDetail(null,null);
            query.BookID = 1;

            //Arc
            GetBookDetailValidator validator = new GetBookDetailValidator();
            var result = validator.Validate(query);

            //Assert
            result.Errors.Count.Should().Equals(0);
            
        }
    }
}