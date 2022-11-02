namespace OVB.Demos.Ecommerce.Microsservices.User.Domain.Contracts.Services.Logging;

public interface ILoggingService
{
    public Task AddNewLogErrorInformation(string errorMessage);
    public Task AddNewLogSuccessInformation(string successInformation);
}
