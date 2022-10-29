using OVB.Demos.Ecommerce.Microsservices.User.Domain.Models.ValueObjects.ENUMs;
using System.Text;

namespace OVB.Demos.Ecommerce.Microsservices.User.Domain.Contracts.Services.Caching;

public abstract class CachingServiceBase
{
    private string IdentifierValue { get; }
    private string Description { get; }
    private TypeCachingTimeService TypeCachingTimeService { get; }
    private TypeCachingService TypeCachingService { get; }
    public int Time { get; private set; }

    protected CachingServiceBase(Guid identifier, TypeCachingTimeService typeCachingTimeService, TypeCachingService typeCachingService, string description)
    {
        IdentifierValue = identifier.ToString();
        TypeCachingTimeService = typeCachingTimeService;
        TypeCachingService = typeCachingService;
        CreateCachingTime();
        Description = description;
    }

    public virtual string GetCachingServiceDeclarationDescription()
    {
        var stringBuilder = new StringBuilder();
        stringBuilder.Append(IdentifierValue);
        stringBuilder.Append("_");
        stringBuilder.Append("RequestService_");
        stringBuilder.Append(Description);
        return stringBuilder.ToString();
    }

    protected virtual void CreateCachingTime()
    {
        Time = 2;
    }
}
