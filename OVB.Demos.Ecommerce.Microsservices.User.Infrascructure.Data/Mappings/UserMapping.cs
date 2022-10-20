using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OVB.Demos.Ecommerce.Microsservices.User.Domain.Contracts.Mappings;
using OVB.Demos.Ecommerce.Microsservices.User.Domain.Models.Entities;

namespace OVB.Demos.Ecommerce.Microsservices.User.Infrascructure.Data.Mappings;

public class UserMapping : IBaseMapping<UserEntity>
{
    public void CreateMapping(EntityTypeBuilder<UserEntity> entity)
    {
        entity.HasKey(p => p.Identifier);

        entity.ToTable("Usuarios");
    }
}
