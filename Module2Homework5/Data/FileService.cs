using Module2Homework5.Configuration;

namespace Module2Homework5.Data
{
    public static class FileService
    {
        private static readonly ConfigurationManager _configurationManager = new ConfigurationManager();

        public static void CreateNewTextFile(string name)
        {
            string path = _configurationManager.GetPath() + name;
            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine("Hello");
                    sw.WriteLine("And");
                    sw.WriteLine("Welcome");
                }
            }
        }
    }
}
