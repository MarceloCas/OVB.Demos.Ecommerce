namespace OVB.Demos.Ecommerce.Microsservices.User.Domain.Contracts.Services.Handler;

public interface IRequest
{
    public Guid Identifier { get; }
    public DateTime Time { get; }
}
