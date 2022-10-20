using OVB.Demos.Ecommerce.Microsservices.User.Domain.Models.ValueObjects.ENUMs;

namespace OVB.Demos.Ecommerce.Microsservices.User.Domain.Models.DTOs.User;

public class UserStandard : UserBase
{
    public UserStandard(Guid identifier, string username, string nameComplete, TypeUser typeUser, int points) : base(identifier, username, nameComplete, TypeUser.Standard, points)
    {
    }
}
