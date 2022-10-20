namespace OVB.Demos.Ecommerce.Microsservices.User.Domain.Models.ValueObjects;

public class PasswordEncrypted
{
    private string Value { get; }

    public PasswordEncrypted(string value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return Value;
    }
}
