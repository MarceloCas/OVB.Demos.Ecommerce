using OVB.Demos.Ecommerce.Microsservices.User.Domain.Contracts.Services.Handler;

namespace OVB.Demos.Ecommerce.Microsservices.User.Services.Handler.CreateAuthentication;

public class CreateAuthenticationRequest : IRequest
{
    public Guid Identifier { get; }
    public DateTime Time { get; }

    public CreateAuthenticationRequest(Guid identifier, DateTime time)
    {
        Identifier = identifier;
        Time = time;
    }
}
