namespace OVB.Demos.Ecommerce.Microsservices.User.Domain.Models.DTOs;

public abstract class UserBase
{
    public Guid Identifier { get; }
    public string Username { get; }

    protected UserBase(Guid identifier, string username)
    {
        Identifier = identifier;
        Username = username;
    }
}
