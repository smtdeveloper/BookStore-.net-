using FluentValidation;
using WebApi.Application.BookOprations;

namespace WebApi.Validator
{

    public class DeleteBookValidator : AbstractValidator<DeleteBook>
    {

      public DeleteBookValidator()
      {
        RuleFor(x => x.BlogID).GreaterThan(0);
        

      }
}
}