namespace OVB.Demos.Ecommerce.Microsservices.User.Domain.Models.ValueObjects;

public class Email
{
    private string Value { get; }

    public Email(string value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return Value;
    }
}
