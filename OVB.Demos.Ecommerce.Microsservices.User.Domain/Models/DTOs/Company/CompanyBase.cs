using OVB.Demos.Ecommerce.Microsservices.User.Domain.Models.DTOs.Employee;
using OVB.Demos.Ecommerce.Microsservices.User.Domain.Models.ValueObjects;
using OVB.Demos.Ecommerce.Microsservices.User.Domain.Models.ValueObjects.ENUMs;

namespace OVB.Demos.Ecommerce.Microsservices.User.Domain.Models.DTOs.Company;

public abstract class CompanyBase
{
    // Company Properties
    public Guid Identifier { get; }
    public CompanyName CompanyName { get; }

    // Company Type
    public TypeCompany TypeCompany { get; }

    // Information
    public List<EmployeeBase> Employees { get; }

    // Constructor
    protected CompanyBase(Guid identifier, CompanyName companyName, List<EmployeeBase> employees)
    {
        Identifier = identifier;
        CompanyName = companyName;
        Employees = employees;
    }

    public void AddEmployeeInCompany(EmployeeBase employee)
    {
        Employees.Add(employee);
    }
}