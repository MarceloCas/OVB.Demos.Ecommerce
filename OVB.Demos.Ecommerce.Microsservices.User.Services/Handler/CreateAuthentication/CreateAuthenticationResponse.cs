using FluentValidation.Results;
using OVB.Demos.Ecommerce.Microsservices.User.Domain.Contracts.Services.Handler;

namespace OVB.Demos.Ecommerce.Microsservices.User.Services.Handler.CreateAuthentication;

public class CreateAuthenticationResponse : IResponse
{
    public Guid Identifier { get; }
    public int Status { get; }
    public List<ValidationFailure> ValidationFailures { get; }

    public CreateAuthenticationResponse(Guid identifier, int status)
    {
        Identifier = identifier;
        Status = status;
        ValidationFailures = new List<ValidationFailure>();
    }

    public CreateAuthenticationResponse(Guid identifier, int status, List<ValidationFailure> validationFailures)
    {
        Identifier = identifier;
        Status = status;
        ValidationFailures = validationFailures;
    }
}
