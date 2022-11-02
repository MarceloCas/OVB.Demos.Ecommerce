using OVB.Demos.Ecommerce.Microsservices.User.Domain.Contracts.Services.Logging;
using System.IO;

namespace OVB.Demos.Ecommerce.Microsservices.User.Services.Logging;

public class LoggingService : ILoggingService
{
    private readonly string CurrentDirectory;
    private readonly string LogsErrorDirectory;
    private readonly string LogsSuccessDirectory;

    public LoggingService()
    {
        CurrentDirectory = Environment.CurrentDirectory;
        LogsErrorDirectory = $@"{CurrentDirectory}\\logs\\errorLogs.txt";
        LogsSuccessDirectory = $@"{CurrentDirectory}\\logs\\successLogs.txt";
    }

    public async Task AddNewLogErrorInformation(string errorMessage)
    {
        using var file = File.AppendText(LogsErrorDirectory);
        await file.WriteLineAsync(DateTime.Now.ToString() + " | ERROR | " + errorMessage);
        await file.DisposeAsync();
    }

    public async Task AddNewLogSuccessInformation(string successInformation)
    {
        using var file = File.AppendText(LogsSuccessDirectory);
        await file.WriteLineAsync(DateTime.Now.ToString() + " | SUCCESS | " + successInformation);
        await file.DisposeAsync();
    }
}
