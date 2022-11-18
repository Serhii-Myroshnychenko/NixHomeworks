using Module2Homework5.Base;

namespace Module2Homework5.Contracts
{
    public interface ILogger
    {
        void AddToLogs(LogTypes type, string message);
        void GetLogs();
    }
}
