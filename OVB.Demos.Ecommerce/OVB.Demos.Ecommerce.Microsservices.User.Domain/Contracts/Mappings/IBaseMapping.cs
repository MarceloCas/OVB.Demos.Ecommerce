using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OVB.Demos.Ecommerce.Microsservices.User.Domain.Contracts.Mappings;

public interface IBaseMapping<T> where T : class
{
    public void CreateMapping(EntityTypeBuilder<T> entity);
}
