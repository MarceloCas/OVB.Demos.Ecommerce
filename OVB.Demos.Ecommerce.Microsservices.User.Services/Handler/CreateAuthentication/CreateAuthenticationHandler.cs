using OVB.Demos.Ecommerce.Microsservices.User.Domain.Contracts.Services.Handler;

namespace OVB.Demos.Ecommerce.Microsservices.User.Services.Handler.CreateAuthentication;

public class CreateAuthenticationHandler : HandlerBase<CreateAuthenticationResponse, CreateAuthenticationRequest>
{
    public CreateAuthenticationHandler() : base(){}

    public override CreateAuthenticationResponse Handle(CreateAuthenticationRequest request)
    {
        throw new NotImplementedException();
    }
}
