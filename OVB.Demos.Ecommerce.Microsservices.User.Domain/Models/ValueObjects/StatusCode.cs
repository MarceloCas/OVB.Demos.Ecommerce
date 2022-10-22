namespace OVB.Demos.Ecommerce.Microsservices.User.Domain.Models.ValueObjects;

public class StatusCode
{
    public string Value { get; }

    public StatusCode(string value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return Value;
    }
}
