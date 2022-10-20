using OVB.Demos.Ecommerce.Microsservices.User.Domain.Models.ValueObjects;
using OVB.Demos.Ecommerce.Microsservices.User.Domain.Models.ValueObjects.ENUMs;

namespace OVB.Demos.Ecommerce.Microsservices.User.Domain.Models.DTOs.User;

public abstract class UserBase
{
    // User Properties
    public Guid Identifier { get; }
    public Username Username { get; }
    public NameComplete NameComplete { get; }
    public Points Points { get; }
    public TypeUser TypeUser { get; }
    private PasswordEncrypted PasswordEncrypted { get; }

    // Constructor
    protected UserBase(Guid identifier, Username username, NameComplete nameComplete, TypeUser typeUser, Points points, PasswordEncrypted passwordEncrypted)
    {
        Identifier = identifier;
        Username = username;
        NameComplete = nameComplete;
        TypeUser = typeUser;
        Points = points;
        PasswordEncrypted = passwordEncrypted;
    }
}
