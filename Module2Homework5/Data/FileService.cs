using Module2Homework5.Configuration;
using Module2Homework5.Utils;

namespace Module2Homework5.Data
{
    public static class FileService
    {
        private static readonly ConfigurationManager _configurationManager = new ();

        public static void WriteLogsToFile(string[] logs)
        {
            if (GetNumberOfFilesInFolder() > 3)
            {
                DeleteOldestFile();
            }

            File.WriteAllText(GetFullPath(), Converter.ConvertLogsToText(logs));
        }

        private static int GetNumberOfFilesInFolder()
        {
            return Directory.GetFiles(_configurationManager.GetPath()).Length;
        }

        private static void DeleteOldestFile()
        {
            File.Delete(Directory.EnumerateFiles(_configurationManager.GetPath())
                .OrderBy(x => new FileInfo(x).LastWriteTime).First());
        }

        private static string GetFullPath()
        {
            return _configurationManager.GetPath() + DateTime.Now.ToString("hh.mm.ss dd.MM.yyyy") + ".txt";
        }
    }
}
