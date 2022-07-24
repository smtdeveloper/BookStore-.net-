using FluentValidation;
using WebApi.Application.BookOprations;

namespace WebApi.Validator
{

    public class UpdateBookValidator : AbstractValidator<UpdateBook>
    {

      public UpdateBookValidator()
      {
       RuleFor(x => x.BookID).GreaterThan(0);
       RuleFor(x => x.Model.GenreID).GreaterThan(0);
       RuleFor(x => x.Model.Title).NotEmpty().MinimumLength(4);

      }
    
    }
}