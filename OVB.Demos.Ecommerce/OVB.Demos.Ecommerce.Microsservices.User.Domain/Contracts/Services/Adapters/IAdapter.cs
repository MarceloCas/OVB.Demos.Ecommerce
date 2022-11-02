namespace OVB.Demos.Ecommerce.Microsservices.User.Domain.Contracts.Services.Adapters;

public interface IAdapter<Adaptee, Target> where Adaptee : class where Target : class
{
    public abstract Adaptee Adapt(Target target);
}
