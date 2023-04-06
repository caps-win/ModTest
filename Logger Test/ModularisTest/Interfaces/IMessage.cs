using ModularisTest.Enums;

namespace ModularisTest.Interfaces
{
    public interface IMessage
    {
        void LogMessage(LogLevel messageType, string message);
    }
}