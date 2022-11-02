namespace OVB.Demos.Ecommerce.Microsservices.User.Domain.Models.Entities;

public class UserEntity
{
    public Guid Identifier { get; set; }
    public string Username { get; set; }
    public string NameComplete { get; set; }
    public int Points { get; set; }
    public string Email { get; set; }
    public string Password { get; set;  }
    public string TypeUser { get; set; }

    public UserEntity(Guid identifier, string username, string nameComplete, int points, string email, string password, string typeUser)
    {
        this.Identifier = identifier;
        this.Username = username;
        this.NameComplete = nameComplete;
        this.TypeUser = typeUser;
        this.Email = email;
        this.Password = password;
        this.Points = points;
    }
}
