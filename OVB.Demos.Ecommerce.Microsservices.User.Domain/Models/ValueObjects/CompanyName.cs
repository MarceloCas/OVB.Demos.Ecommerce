namespace OVB.Demos.Ecommerce.Microsservices.User.Domain.Models.ValueObjects;

public class CompanyName
{
    private string Value { get; }

    public CompanyName(string value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return Value.ToString();
    }
}
