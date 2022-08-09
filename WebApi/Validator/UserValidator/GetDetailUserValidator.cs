using FluentValidation;
using WebApi.Application.BookOprations;
using WebApi.Application.UserOperations.Commands;
using WebApi.Application.UserOperations.Queries;

namespace WebApi.Validator.UserValidator
{
    public class GetDetailUserValidator : AbstractValidator<GetDetailUserQuery>
    {

      public GetDetailUserValidator()
      {
        
        RuleFor(x => x.UserID).NotEmpty().WithMessage("Id boş olamaz ! ");
        
      }

    }
}
