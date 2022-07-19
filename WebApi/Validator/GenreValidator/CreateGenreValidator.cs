using FluentValidation;
using WebApi.Application.GenreOperations.Commands;

namespace WebApi.Validator.GenreValidator
{

    public class CreateGenreValidator : AbstractValidator<CreateGenreCommand>
    {

      public CreateGenreValidator()
      {
        RuleFor(x => x.Model.Name).MinimumLength(4).NotEmpty();
        
      }
      
    }
}
        