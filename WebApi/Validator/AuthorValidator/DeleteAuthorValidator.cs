using FluentValidation;
using WebApi.Application.AuthorOprations;

namespace WebApi.Validator.AuthorValidator
{

    public class DeleteAuthorValidator : AbstractValidator<DeleteAuthor>
    {

      public DeleteAuthorValidator()
      {
        RuleFor(x => x.AuthorID).GreaterThan(0);
      }
      
    }
}
        