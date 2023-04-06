using ModularisTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ModularisTestUnitTests
{
    [TestClass]
    public class JobLoggerTest
    {
        private const string TestMessage = "Test Message";
        private const string WarningMessage = "Test Warning";
        private const string ErrorMessage = "Test Error";

        [TestMethod]
        public void JobLoggerBasicTest()
        {
            // var jobLogger = new JobLogger(true, true, true, true, true);
             JobLogger.Message(TestMessage);
             JobLogger.Error(ErrorMessage);
             JobLogger.Warning(WarningMessage);
        }
    }
}