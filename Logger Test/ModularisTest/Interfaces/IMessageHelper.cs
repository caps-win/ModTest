using ModularisTest.Enums;

namespace ModularisTest.Interfaces
{
    public interface IMessageHelper
    {
        string StructureMessage(LogLevel logLevel,string message);
    }
}