using FluentValidation;
using WebApi.Application.BookOprations;
using WebApi.Application.UserOperations.Commands;

namespace WebApi.Validator.UserValidator
{
    public class DeleteUserValidator : AbstractValidator<DeleteUserCommand>
    {

      public DeleteUserValidator()
      {
        RuleFor(x => x.UserID).NotEmpty().GreaterThan(0);
      }

    }
}
