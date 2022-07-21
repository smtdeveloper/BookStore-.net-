using FluentValidation;
using WebApi.Application.AuthorOprations;
using WebApi.Application.GenreOperations.Commands;

namespace WebApi.Validator.AuthorValidator
{

    public class CreateAuthorValidator : AbstractValidator<CreateAuthor>
    {

      public CreateAuthorValidator()
      {

        RuleFor(x => x.Model.Name).MinimumLength(2).NotEmpty();
        RuleFor(x => x.Model.LastName).MinimumLength(2).NotEmpty();
        RuleFor(x => x.Model.BookId).NotEmpty().GreaterThan(0);
        
      }
      
    }
}
        