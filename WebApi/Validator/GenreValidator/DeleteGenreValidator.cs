using FluentValidation;
using WebApi.Application.GenreOperations.Commands;

namespace WebApi.Validator.GenreValidator
{

    public class DeleteGenreValidator : AbstractValidator<DeleteGenreCommand>
    {

      public DeleteGenreValidator()
      {
        RuleFor(x => x.GenreId).GreaterThan(0);
        
      }
      
    }
}
        