namespace OVB.Demos.Ecommerce.Microsservices.User.Domain.Contracts.Services.Handler;

public interface IResponse
{
    public Guid Identifier { get; }
    public int Status { get; }
}
