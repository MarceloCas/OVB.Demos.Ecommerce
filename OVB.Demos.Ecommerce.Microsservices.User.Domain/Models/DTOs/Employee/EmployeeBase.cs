using OVB.Demos.Ecommerce.Microsservices.User.Domain.Models.ValueObjects;

namespace OVB.Demos.Ecommerce.Microsservices.User.Domain.Models.DTOs.Employee;

public abstract class EmployeeBase
{
    public Guid Identifier { get; }
    public NameComplete NameComplete { get; }

    protected EmployeeBase(Guid identifier, NameComplete nameComplete)
    {
        Identifier = identifier;
        NameComplete = nameComplete;
    }
}
