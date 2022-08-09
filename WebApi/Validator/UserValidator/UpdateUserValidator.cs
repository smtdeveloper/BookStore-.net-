using FluentValidation;
using WebApi.Application.BookOprations;
using WebApi.Application.UserOperations.Commands;

namespace WebApi.Validator.UserValidator
{
    public class UpdateUserValidator : AbstractValidator<UpdateUserCommand>
    {

      public UpdateUserValidator()
      {
        
        RuleFor(x => x.UserID).NotEmpty().GreaterThan(0);
        RuleFor(x => x.Model.Name).NotEmpty();
        RuleFor(x => x.Model.LastName).NotEmpty();
        RuleFor(x => x.Model.Password).NotEmpty().MinimumLength(6);
        
        
      }

    }
}
