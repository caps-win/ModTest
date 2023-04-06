using ModularisTest.Enums;

namespace ModularisTest.Interfaces
{
    public interface ILoggerEvent
    {
        void Write(LogLevel messageType, string message);
    }
}