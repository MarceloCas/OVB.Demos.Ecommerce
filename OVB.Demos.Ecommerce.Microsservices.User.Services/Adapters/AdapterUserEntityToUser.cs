using OVB.Demos.Ecommerce.Microsservices.User.Domain.Contracts.Services.Adapters;
using OVB.Demos.Ecommerce.Microsservices.User.Domain.Models.DTOs.User;
using OVB.Demos.Ecommerce.Microsservices.User.Domain.Models.Entities;
using OVB.Demos.Ecommerce.Microsservices.User.Domain.Models.ValueObjects;

namespace OVB.Demos.Ecommerce.Microsservices.User.Services.Adapters;

public class AdapterUserEntityToUser : IAdapter<UserBase, UserEntity>
{
    public UserBase Adapt(UserEntity target)
    {
        return new UserStandard(target.Identifier, new Username(target.Username), new NameComplete(target.NameComplete), new Points(target.Points), new PasswordEncrypted(target.Password), new Email(target.Email));
    }
}
