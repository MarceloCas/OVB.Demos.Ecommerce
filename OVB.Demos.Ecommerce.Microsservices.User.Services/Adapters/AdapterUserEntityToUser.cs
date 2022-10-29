using OVB.Demos.Ecommerce.Microsservices.User.Domain.Contracts.Services.Adapters;
using OVB.Demos.Ecommerce.Microsservices.User.Domain.Models.DTOs.User;
using OVB.Demos.Ecommerce.Microsservices.User.Domain.Models.Entities;

namespace OVB.Demos.Ecommerce.Microsservices.User.Services.Adapters;

public class AdapterUserEntityToUser : IAdapter<UserBase, UserEntity>
{
    public UserBase Adapt(UserEntity target)
    {
        throw new NotImplementedException();
    }
}
