using System;
using System.Collections.Generic;
using ModularisTest.Enums;
using ModularisTest.Interfaces;

namespace ModularisTest.LogOutput
{
    public class ConsoleLogger: IMessage
    {
        private readonly IMessageHelper _messageHelper;
        public ConsoleLogger(IMessageHelper messageHelper)
        {
            _messageHelper = messageHelper;
        }
        public void LogMessage(LogLevel messageType, string message)
        {
            Console.ForegroundColor = SetForegroundColor(messageType);
            string structuredMessage = _messageHelper.StructureMessage(messageType, message);
            Console.WriteLine(structuredMessage);
        }

        private ConsoleColor SetForegroundColor(LogLevel messageType)
        {
            Dictionary<LogLevel, ConsoleColor> consoleColors = new Dictionary<LogLevel, ConsoleColor>()
            {
                { LogLevel.Message , ConsoleColor.White},
                { LogLevel.Warning , ConsoleColor.Yellow},
                { LogLevel.Error , ConsoleColor.Red}

            };
            return consoleColors[messageType];
        }
    }

}