namespace OVB.Demos.Ecommerce.Microsservices.User.Domain.Models.ValueObjects;

public class Username
{
    private string Value { get; }

    public Username(string value )
    {
        Value = value;
    }
    
    public override string ToString()
    {
        return Value;
    }
}
