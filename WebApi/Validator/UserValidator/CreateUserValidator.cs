using FluentValidation;
using WebApi.Application.BookOprations;
using WebApi.Application.UserOperations.Commands;

namespace WebApi.Validator.UserValidator
{
    public class CreateUserValidator : AbstractValidator<CreateUserCommand>
    {

      public CreateUserValidator()
      {
        
        RuleFor(x => x.Model.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.Model.Name).NotEmpty();
        RuleFor(x => x.Model.LastName).NotEmpty();
        RuleFor(x => x.Model.Password).NotEmpty().MinimumLength(6);
        
      }

    }
}
