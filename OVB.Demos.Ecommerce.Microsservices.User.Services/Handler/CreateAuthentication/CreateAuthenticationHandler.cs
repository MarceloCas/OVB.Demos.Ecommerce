using OVB.Demos.Ecommerce.Microsservices.User.Domain.Contracts.Services.Handler;

namespace OVB.Demos.Ecommerce.Microsservices.User.Services.Handler.CreateAuthentication;

public class CreateAuthenticationHandler : HandlerBase<IResponse, IRequest>
{
    public CreateAuthenticationHandler() : base(){}

    public override IResponse Handle(IRequest request)
    {
        throw new NotImplementedException();
    }
}
