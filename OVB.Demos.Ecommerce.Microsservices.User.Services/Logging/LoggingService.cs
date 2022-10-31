using OVB.Demos.Ecommerce.Microsservices.User.Domain.Contracts.Services.Logging;

namespace OVB.Demos.Ecommerce.Microsservices.User.Services.Logging;

public class LoggingService : ILoggingService
{
    public Task AddNewLogErrorInformation(string errorMessage)
    {
        throw new NotImplementedException();
    }
}
