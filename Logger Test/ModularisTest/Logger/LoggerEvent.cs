using System;
using System.Collections.Generic;
using ModularisTest.Configuration;
using ModularisTest.DataAccess;
using ModularisTest.Enums;
using ModularisTest.Formating;
using ModularisTest.Interfaces;
using ModularisTest.LogOutput;
using ModularisTest.Utility;

namespace ModularisTest.Logger
{
    public class LoggerEvent : ILoggerEvent
    {
        private readonly IEnumerable<IMessage> _logDestinations;
        private readonly ISettings _settings;

        public LoggerEvent()
        {
            _settings = Settings.GetInstance();
            var logConfiguration = new LogConfiguration(_settings);
            var logDestinationTypes = logConfiguration.GetDestinationsTypes();
            _logDestinations = GetLogDestinations(logDestinationTypes);
        }
        
        private IEnumerable<IMessage> GetLogDestinations(IEnumerable<DestinationType> logDestinationTypes)
        {
            var destinationResult = new List<IMessage>();
            IMessageHelper messageHelper = new MessageHelper();
            foreach (var destinationType in logDestinationTypes)
            {
                switch (destinationType)
                {
                    case DestinationType.Console :
                        destinationResult.Add(new ConsoleLogger(messageHelper)); 
                        break;
                    case DestinationType.File :
                        IFile fileManager = FileManager.GetInstance();
                        destinationResult.Add(new FileLogger(fileManager, messageHelper, _settings)); 
                        break;
                    case DestinationType.Database :
                        IDbContext dbContext = new DbContext(_settings);
                        destinationResult.Add(new DatabaseLogger(dbContext, _settings)); 
                        break;
                    default:
                        throw new NullReferenceException("DestinationType not supported.");
                }
            }

            return destinationResult;
        }

        public void Write(LogLevel messageType, string message)
        {
            foreach (var logDestination in _logDestinations)
            {
                logDestination.LogMessage(messageType, message);
            }
        }
    }

}