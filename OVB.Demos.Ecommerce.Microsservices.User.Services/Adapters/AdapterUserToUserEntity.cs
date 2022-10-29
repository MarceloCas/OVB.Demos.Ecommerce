using OVB.Demos.Ecommerce.Microsservices.User.Domain.Contracts.Services.Adapters;
using OVB.Demos.Ecommerce.Microsservices.User.Domain.Models.DTOs.User;
using OVB.Demos.Ecommerce.Microsservices.User.Domain.Models.Entities;

namespace OVB.Demos.Ecommerce.Microsservices.User.Services.Adapters;

public class AdapterUserToUserEntity : IAdapter<UserEntity, UserBase>
{
    public UserEntity Adapt(UserBase target)
    {
        throw new NotImplementedException();
    }
}