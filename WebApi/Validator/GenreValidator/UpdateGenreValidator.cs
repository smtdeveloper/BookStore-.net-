using FluentValidation;
using WebApi.Application.GenreOperations.Commands;

namespace WebApi.Validator.GenreValidator
{

    public class UpdateGenreValidator : AbstractValidator<UpdateGenreCommand>
    {

      public UpdateGenreValidator()
      {
        RuleFor(x => x.Model.Name).MaximumLength(4)
        .When(x => x.Model.Name != string.Empty);

      }
      
    }
}
        