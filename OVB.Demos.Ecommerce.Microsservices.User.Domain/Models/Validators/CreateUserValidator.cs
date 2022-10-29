using FluentValidation;
using OVB.Demos.Ecommerce.Microsservices.User.Domain.Models.DTOs.User;
using System.Text.RegularExpressions;

namespace OVB.Demos.Ecommerce.Microsservices.User.Domain.Models.Validators;

public class CreateUserValidator : AbstractValidator<UserBase>
{
    public CreateUserValidator()
    {
        RuleFor(p => p.Identifier).NotEmpty().WithMessage("The identifier is required.");
        RuleFor(p => p.Identifier).NotNull().WithMessage("The identifier is required.");
        RuleFor(p => p.Identifier.ToString()).Matches(@"^[a-zA-Z0-9]{8}-[a-zA-Z0-9]{4}-[a-zA-Z0-9]{4}-[a-zA-Z0-9]{4}-[a-zA-Z0-9]{12}$").WithMessage("The identifier needs to be correct form.");
    }
}
