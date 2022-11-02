using OVB.Demos.Ecommerce.Microsservices.User.Domain.Contracts.Services.Logging;
using System.IO;

namespace OVB.Demos.Ecommerce.Microsservices.User.Services.Logging;

public class LoggingService : ILoggingService
{
    private readonly string CurrentDirectory;
    private readonly string LogsDirectory;


    public LoggingService()
    {
        CurrentDirectory = Environment.CurrentDirectory;
        LogsDirectory = $@"{CurrentDirectory}\\logs.txt";
    }

    public async Task AddNewLogErrorInformation(string errorMessage)
    {
        using var file = File.AppendText(LogsDirectory);
        await file.WriteLineAsync(DateTime.Now.ToString() + " | " + errorMessage);
        await file.DisposeAsync();
    }
}
