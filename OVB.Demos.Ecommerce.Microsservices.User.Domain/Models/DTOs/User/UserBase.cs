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
    public Username Username { get; private set; }
    public NameComplete NameComplete { get; private set; }
    public Points Points { get; private set; }
    public Email Email { get; private set; }
    public PasswordEncrypted PasswordEncrypted { get; private set; }

    // Access Properties
    public TypeUser TypeUser { get; }
    #endregion

    #region Constructor
    // Constructor
    protected UserBase(Guid identifier, Username username, NameComplete nameComplete, TypeUser typeUser, Points points, PasswordEncrypted passwordEncrypted, Email email)
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
