using FluentValidation;
using WebApi.Application.BookOprations;

namespace WebApi.Validator.BookValidator
{

    public class GetBookDetailValidator : AbstractValidator<GetBookDetail>
    {

      public GetBookDetailValidator()
      {
        RuleFor(x => x.BookID).GreaterThan(0);
        RuleFor(x => x.BookID).NotEmpty().WithMessage("ID Boş Geçilemez!");

      }

    }
}
        