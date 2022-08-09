using FluentValidation;
using WebApi.Application.BookOprations;

namespace WebApi.Validator.BookValidator
{

    public class CreateBookValidator : AbstractValidator<CreateBook>
    {

      public CreateBookValidator()
      {
        
        RuleFor(x => x.Model.GenreId).GreaterThan(0);
        RuleFor(x => x.Model.PageCount).GreaterThan(0);
        RuleFor(x => x.Model.PublisDate.Date).NotEmpty().LessThan(DateTime.Now.Date);
        RuleFor(x => x.Model.Title).NotEmpty().MinimumLength(4);

      }

    }
}