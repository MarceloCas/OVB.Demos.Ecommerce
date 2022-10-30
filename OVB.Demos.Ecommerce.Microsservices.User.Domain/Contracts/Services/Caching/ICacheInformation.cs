namespace OVB.Demos.Ecommerce.Microsservices.User.Domain.Contracts.Services.Caching;

public interface ICacheInformation
{
    int Time { get; }
    string GetCachingServiceDeclarationDescription();
}
