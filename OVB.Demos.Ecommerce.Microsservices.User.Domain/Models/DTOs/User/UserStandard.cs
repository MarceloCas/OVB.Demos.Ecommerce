using OVB.Demos.Ecommerce.Microsservices.User.Domain.Models.ValueObjects;
using OVB.Demos.Ecommerce.Microsservices.User.Domain.Models.ValueObjects.ENUMs;

namespace OVB.Demos.Ecommerce.Microsservices.User.Domain.Models.DTOs.User;

public class UserStandard : UserBase
{
    public UserStandard(Guid identifier, Username username, NameComplete nameComplete, Points points, PasswordEncrypted passwordEncrypted, Email email) : base(identifier, username, nameComplete, TypeUser.Standard, points, passwordEncrypted, email)
    {
    }
}
