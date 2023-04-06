using System.IO;
using ModularisTest.Interfaces;

namespace ModularisTest.Utility
{
    public sealed class FileManager : IFile
    {
        private static FileManager _instance = null;

        private FileManager()
        {
        }

        public static FileManager GetInstance()
        {
            if (_instance == null)
            {
                _instance = new FileManager();
            }

            return _instance;
        }


        public void CreateOrUpdateFile(string message, string directory, string fileName)
        {
            var fullFilePath = Path.Combine(directory, fileName);
            var sw = File.AppendText(fullFilePath);
            sw.WriteLine(message);
            sw.Close();
        }

    }
}