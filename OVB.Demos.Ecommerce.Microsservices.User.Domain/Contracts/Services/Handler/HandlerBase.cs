namespace OVB.Demos.Ecommerce.Microsservices.User.Domain.Contracts.Services.Handler;

public abstract class HandlerBase<T,K> where T : IResponse where K : IRequest
{
    public Guid Identifier { get; }
    
    protected HandlerBase()
    {
        Identifier = Guid.NewGuid();
    }

    public abstract Task<T> Handle(K request);
}