namespace AspNetCoreSoapAuthBasicService
{
    public interface ILoggingManager
    {
        void LogInformation(string message);
        void LogError(string message);

    }
}
