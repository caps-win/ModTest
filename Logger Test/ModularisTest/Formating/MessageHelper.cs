using System;
using ModularisTest.Enums;
using ModularisTest.Interfaces;

namespace ModularisTest.Formating
{
    public class MessageHelper : IMessageHelper
    {
        public string StructureMessage(LogLevel logLevel, string message)
        {
            DateTime currentDate = DateTime.UtcNow;
            return $"[{currentDate}] [{logLevel}] - {message}";
        }
    }
}