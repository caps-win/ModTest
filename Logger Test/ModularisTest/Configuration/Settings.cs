using System;
using System.Collections.Generic;
using System.Configuration;
using ModularisTest.Interfaces;

namespace ModularisTest.Configuration
{
    public class Settings: ISettings
    {
        private static Settings _instance = null;

        private Dictionary<string, string> _storeValues { get; set; } = new Dictionary<string, string>();
        private Settings()
        {
            
        }

        public static Settings GetInstance()
        {
            if (_instance == null) 
            {
                _instance = new Settings();
            }

            return _instance;
        }
        public  string GetValue(string key)
        {
            if (_storeValues.ContainsKey(key))
            {
                return _storeValues[key];
            }

            string storedValue = ConfigurationManager.AppSettings[key];
            if (string.IsNullOrEmpty(storedValue))
            {
                throw new ArgumentException($"The key {key} does not exist.");
            }
            _storeValues[key] = storedValue;
            return storedValue;
        }
    }
}