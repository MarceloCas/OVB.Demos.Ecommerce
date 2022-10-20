using OVB.Demos.Ecommerce.Microsservices.User.Domain.Models.ValueObjects.ENUMs;

namespace OVB.Demos.Ecommerce.Microsservices.User.Domain.Models.DTOs.User;

public abstract class UserBase
{
    // User Properties
    public Guid Identifier { get; }
    public string Username { get; }
    public string NameComplete { get; }
    public int Points { get; }
    public TypeUser TypeUser { get; }
    private string PasswordEncrypted { get; }

    // Constructor
    protected UserBase(Guid identifier, string username, string nameComplete, TypeUser typeUser, int points, string passwordEncrypted)
    {
        Identifier = identifier;
        Username = username;
        NameComplete = nameComplete;
        TypeUser = typeUser;
        Points = points;
        PasswordEncrypted = passwordEncrypted;
    }
}
