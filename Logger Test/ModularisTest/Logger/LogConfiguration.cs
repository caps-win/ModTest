using System;
using System.Collections.Generic;
using System.Linq;
using ModularisTest.Enums;
using ModularisTest.Interfaces;

namespace ModularisTest.Logger
{
    public class LogConfiguration
    {
        private readonly ISettings _settings;

        public LogConfiguration(ISettings settings)
        {
            _settings = settings;
        }
        public  IEnumerable<DestinationType> GetDestinationsTypes()
        {
            var value = _settings.GetValue("logDestination");

            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("There are not configured any destination");
            }

            var splitContent = value.Split(',');
            
            return splitContent
                .Select(x => (DestinationType)Enum.Parse(typeof(DestinationType), x));
        }
    }
}