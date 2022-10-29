using FluentValidation;
using OVB.Demos.Ecommerce.Microsservices.User.Domain.Contracts.Services.Handler;
using OVB.Demos.Ecommerce.Microsservices.User.Domain.Models.DTOs.User;

namespace OVB.Demos.Ecommerce.Microsservices.User.Services.Handler.CreateAuthentication;

public class CreateAuthenticationRequest : IRequest
{
    public Guid Identifier { get; }
    public DateTime Time { get; }
    public AbstractValidator<UserBase> Validator { get; } 
    public UserBase User { get; }

    public CreateAuthenticationRequest(Guid identifier, DateTime time, AbstractValidator<UserBase> createUserValidator, UserBase user)
    {
        Identifier = identifier;
        Time = time;
        Validator = createUserValidator;
        User = user;
    }
}
