namespace OVB.Demos.Ecommerce.Microsservices.User.Domain.Models.ValueObjects;

public class Points
{
    private string Value { get; }

    public Points(string value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return Value;
    }
}
