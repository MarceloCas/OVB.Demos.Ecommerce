using OVB.Demos.Ecommerce.Microsservices.User.Domain.Contracts.Services.Caching;
using OVB.Demos.Ecommerce.Microsservices.User.Domain.Models.ValueObjects.ENUMs;

namespace OVB.Demos.Ecommerce.Microsservices.User.Services.Caching;

public class CachingServiceRequests : CachingServiceBase
{
    private string Description { get; set; }

    public CachingServiceRequests(Guid identifier, TypeCachingTimeService typeCachingTimeService, TypeCachingService typeCachingService, string description) : base(identifier, TypeCachingTimeService.Fast, TypeCachingService.Request)
    {
        Description = description;
    }

    public override string GetCachingServiceDeclarationDescription()
    {
        return $"{Description}_{GetTypeCachingService()}";
    }
}
