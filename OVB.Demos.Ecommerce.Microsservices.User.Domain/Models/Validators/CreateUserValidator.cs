using FluentValidation;
using OVB.Demos.Ecommerce.Microsservices.User.Domain.Models.DTOs.User;
using System.Text.RegularExpressions;

namespace OVB.Demos.Ecommerce.Microsservices.User.Domain.Models.Validators;

public class CreateUserValidator : AbstractValidator<UserBase>
{
    public CreateUserValidator()
    {
        // IDENTIFIER
        RuleFor(p => p.Identifier).NotEmpty().WithMessage("The identifier is required.");
        RuleFor(p => p.Identifier).NotNull().WithMessage("The identifier is required.");
        RuleFor(p => p.Identifier.ToString()).Matches(@"^[a-zA-Z0-9]{8}-[a-zA-Z0-9]{4}-[a-zA-Z0-9]{4}-[a-zA-Z0-9]{4}-[a-zA-Z0-9]{12}$").WithMessage("The identifier needs to be correct form.");

        // NAME COMPLETE
        RuleFor(p => p.NameComplete.Length).LessThanOrEqualTo(25).WithMessage("The name needs less than 25 characters.");
        RuleFor(p => p.NameComplete.Length).GreaterThanOrEqualTo(5).WithMessage("The name needs more than 4 characters");

        // USERNAME
        RuleFor(p => p.Username.Length).LessThanOrEqualTo(18).WithMessage("The username needs less than 18 characters.");
        RuleFor(p => p.Username.Length).GreaterThanOrEqualTo(5).WithMessage("The username needs more than 4 characters");

        // EMAIL
        RuleFor(p => p.Email.Length).LessThanOrEqualTo(42).WithMessage("The email needs less than 42 characters.");
        RuleFor(p => p.Email.Length).GreaterThanOrEqualTo(5).WithMessage("The username needs more than 4 characters");
        RuleFor(p => p.Email).EmailAddress().WithMessage("The email needs to be correct");

        // PASSWORD
        RuleFor(p => p.PasswordEncrypted.Length).LessThanOrEqualTo(42).WithMessage("The password needs less than 32 characters.");
        RuleFor(p => p.PasswordEncrypted.Length).GreaterThanOrEqualTo(8).WithMessage("The password needs more than 7 characters");
        RuleFor(p => p.PasswordEncrypted).Matches(@"(?=.*[a-z])").WithMessage("The password needs a lowercase character.");
        RuleFor(p => p.PasswordEncrypted).Matches(@"(?=.*[A-Z])").WithMessage("The password needs a uppercase character.");
        RuleFor(p => p.PasswordEncrypted).Matches(@"(?=.*[0-9])").WithMessage("The password needs a digit character.");
        RuleFor(p => p.PasswordEncrypted).Matches(@"(?=.*[$*&@#])").WithMessage("The password needs a symbol character.");
    }
}
