using FluentValidation;
using WebApi.Application.GenreOperations.Queries;

namespace WebApi.Validator.GenreValidator
{

    public class GetGenreDetailValidator : AbstractValidator<GetGenreDetailQuery>
    {

      public GetGenreDetailValidator()
      {
        RuleFor(x => x.GenreId).GreaterThan(0);
      }
      
    }
}
        