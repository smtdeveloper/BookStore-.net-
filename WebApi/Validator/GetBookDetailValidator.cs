using FluentValidation;
using WebApi.Application.BookOprations;

namespace WebApi.Validator
{

    public class GetBookDetailValidator : AbstractValidator<GetBookDetail>
    {

      public GetBookDetailValidator()
      {
        RuleFor(x => x.BlogID).GreaterThan(0);
        RuleFor(x => x.BlogID).NotEmpty().WithMessage("ID Boş Geçilemez!");

      }

    }
}
        