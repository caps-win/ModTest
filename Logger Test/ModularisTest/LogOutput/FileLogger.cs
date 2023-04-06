using System;
using ModularisTest.Enums;
using ModularisTest.Interfaces;
using IMessage = ModularisTest.Interfaces.IMessage;

namespace ModularisTest.LogOutput
{
    public class FileLogger: IMessage
    {
        private readonly IFile _file;
        private readonly IMessageHelper _messageHelper;
        private readonly string _directory;

        public FileLogger(IFile file, IMessageHelper messageHelper, ISettings settings)
        {
            _file = file;
            _messageHelper = messageHelper;
            _directory = settings.GetValue("FileDirectory") ?? Environment.CurrentDirectory;
        }
        public void LogMessage(LogLevel messageType, string message)
        {
            var logFileName = "LogFile_" + DateTime.Now.ToShortDateString().Replace("/", ".") + ".txt";
            var structuredMessage = _messageHelper.StructureMessage(messageType, message);
            _file.CreateOrUpdateFile(structuredMessage, _directory, logFileName);
        }
    }
} 