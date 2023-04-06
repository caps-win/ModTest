using ModularisTest.Exceptions;
using System;
using System.Configuration;
using System.IO;
using ModularisTest.Enums;
using ModularisTest.Interfaces;
using ModularisTest.Logger;

namespace ModularisTest
{
    public static class JobLogger
    {
        private static readonly ILoggerEvent LoggerEvent;

        static JobLogger()
        {
            LoggerEvent = new LoggerEvent();
        }

 
        public static void Message(string message)
        {
            Log(LogLevel.Message, message);
        }
        
        public static void Warning(string message)
        {
            Log(LogLevel.Warning, message);
        }
        
        public static void Error(string message)
        {
            Log(LogLevel.Error, message);
        }
        
        private static void Log(LogLevel logLevel, string message)
        {
            LoggerEvent.Write(logLevel, message);
        }
    }
}