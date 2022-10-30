using OVB.Demos.Ecommerce.Microsservices.User.Domain.Models.ValueObjects;
using OVB.Demos.Ecommerce.Microsservices.User.Domain.Models.ValueObjects.ENUMs;

namespace OVB.Demos.Ecommerce.Microsservices.User.Domain.Models.DTOs.User;

/// <summary>
/// Classe base para representação base de usuário
/// </summary>
public abstract class UserBase
{
    #region Properties
    // User Properties
    public Guid Identifier { get; }
    public string Username { get; private set; }
    public string NameComplete { get; private set; }
    public int Points { get; private set; }
    public string Email { get; private set; }
    public string PasswordEncrypted { get; private set; }

    // Access Properties
    public TypeUser TypeUser { get; }
    #endregion

    #region Constructor
    // Constructor
    protected UserBase(Guid identifier, string username, string nameComplete, TypeUser typeUser, int points, string passwordEncrypted, string email)
    {
        Identifier = identifier;
        Username = username;
        NameComplete = nameComplete;
        TypeUser = typeUser;
        Points = points;
        PasswordEncrypted = passwordEncrypted;
        Email = email;
    }
    #endregion

    #region General Methods
    public virtual void IncrementPoints(int quantity)
    {
        var actualPoints = Points.GetValue();
        Points = new Points(actualPoints + quantity);
    }

    public void ChangeEmail(Email email)
    {
        Email = email;
    }

    public void ChangeNameComplete(NameComplete nameComplete)
    {
        NameComplete = nameComplete;
    }

    public void ChangeUsername(Username username)
    {
        Username = username;
    }

    public void ChangePassword(PasswordEncrypted passwordEncrypted)
    {
        PasswordEncrypted = passwordEncrypted;
    }
    #endregion
}
