using System;
using ModularisTest.Enums;
using ModularisTest.Interfaces;

namespace ModularisTest.LogOutput
{
    public class DatabaseLogger: IMessage
    {
        private readonly IDbContext _dbContext;
        private readonly string _table;

        public DatabaseLogger(IDbContext dbContext, ISettings settings)
        {
            _dbContext = dbContext;
            _table = settings.GetValue("LogTable");
        }
        public void LogMessage(LogLevel messageType, string message)
        {
            DateTime currentDate = DateTime.UtcNow;
            string query = $"INSERT INTO {_table}(Message, LogLevel, IssuedAt) VALUES (@Message, @LogLevel, @IssuedAt);";
            object parameters = new
            {
                Message = message,
                LogLevel = messageType.ToString(),
                IssuedAt = currentDate
            };
            _dbContext.RunQuery(query, parameters);
        }
    }
    
}