using OVB.Demos.Ecommerce.Microsservices.User.Domain.Models.ValueObjects.ENUMs;
using System.Text;

namespace OVB.Demos.Ecommerce.Microsservices.User.Domain.Contracts.Services.Caching;

public abstract class CachingServiceBase : ICacheInformation
{
    private string IdentifierValue { get; }
    private TypeCachingTimeService TypeCachingTimeService { get; }
    private TypeCachingService TypeCachingService { get; }
    public int Time { get; private set; }

    protected CachingServiceBase(Guid identifier, TypeCachingTimeService typeCachingTimeService, TypeCachingService typeCachingService)
    {
        IdentifierValue = identifier.ToString();
        TypeCachingTimeService = typeCachingTimeService;
        TypeCachingService = typeCachingService;
        CreateCachingTime();
    }

    public virtual string GetCachingServiceDeclarationDescription()
    {
        var stringBuilder = new StringBuilder();
        stringBuilder.Append(IdentifierValue + "_");
        stringBuilder.Append("RequestService_");
        stringBuilder.Append(GetTypeCachingService() + "_");
        stringBuilder.Append(TypeCachingTimeService.ToString());
        return stringBuilder.ToString();
    }

    protected virtual void CreateCachingTime()
    {
        Time = 1;
    }

    protected string GetTypeCachingService()
    {
        return TypeCachingService.ToString();
    }
}
