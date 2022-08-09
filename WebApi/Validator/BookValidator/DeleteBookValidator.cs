using FluentValidation;
using WebApi.Application.BookOprations;

namespace WebApi.Validator.BookValidator
{

    public class DeleteBookValidator : AbstractValidator<DeleteBook>
    {

      public DeleteBookValidator()
      {
        RuleFor(x => x.BookID).GreaterThan(0);
        

      }
}
}