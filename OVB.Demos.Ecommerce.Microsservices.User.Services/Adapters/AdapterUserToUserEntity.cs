using OVB.Demos.Ecommerce.Microsservices.User.Domain.Contracts.Services.Adapters;
using OVB.Demos.Ecommerce.Microsservices.User.Domain.Models.DTOs.User;
using OVB.Demos.Ecommerce.Microsservices.User.Domain.Models.Entities;

namespace OVB.Demos.Ecommerce.Microsservices.User.Services.Adapters;

public class AdapterUserToUserEntity : IAdapter<UserEntity, UserBase>
{
    public UserEntity Adapt(UserBase target)
    {
        return new UserEntity(target.Identifier, target.Username.ToString(), target.NameComplete.ToString(), target.TypeUser.ToString(), target.Email.ToString(), target.PasswordEncrypted.ToString());
    }
}