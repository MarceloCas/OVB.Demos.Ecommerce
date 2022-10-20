namespace OVB.Demos.Ecommerce.Microsservices.User.Domain.Models.ValueObjects;

public class NameComplete
{
    private string Value { get; }

    public NameComplete(string value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return Value;
    }
}
