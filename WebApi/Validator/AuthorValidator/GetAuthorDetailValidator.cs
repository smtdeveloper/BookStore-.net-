using FluentValidation;
using WebApi.Application.AuthorOprations.Queries;
using WebApi.Application.GenreOperations.Queries;

namespace WebApi.Validator.GenreValidator
{

    public class GetAuthorDetailValidator : AbstractValidator<GetAuthorDetailQuery>
    {

      public GetAuthorDetailValidator()
      {
        RuleFor(x => x.AuthorId).GreaterThan(0);
      }
        
      
    }
}
        