using OVB.Demos.Ecommerce.Microsservices.User.Domain.Contracts.Services.Handler;
using OVB.Demos.Ecommerce.Microsservices.User.Domain.Models.Validators;

namespace OVB.Demos.Ecommerce.Microsservices.User.Services.Handler.CreateAuthentication;

public class CreateAuthenticationHandler : HandlerBase<CreateAuthenticationResponse, CreateAuthenticationRequest>
{
    public CreateAuthenticationHandler() : base()
    {
        
    }

    public override CreateAuthenticationResponse Handle(CreateAuthenticationRequest request)
    {
        var validationResults = request.Validator.Validate(request.User);

        if (validationResults.IsValid == true)
        {
            CreateAuthenticationResponse createAuthenticationResponse = new CreateAuthenticationResponse(Guid.NewGuid(), 200);
        }
        else
        {
            CreateAuthenticationResponse createAuthenticationResponse = new CreateAuthenticationResponse(Guid.NewGuid(), 404, validationResults.Errors);
            return createAuthenticationResponse;
        }

        throw new NotImplementedException();
    }
}
