using Microsoft.Extensions.Configuration;

namespace Module2Homework5.Configuration
{
    public class ConfigurationManager
    {
        private readonly IConfigurationRoot _config;
        public ConfigurationManager()
        {
            _config = new ConfigurationBuilder().AddJsonFile($"configuration.json", true, true).Build();
        }

        public string GetPath()
        {
           return Path.Combine(
                Directory.GetParent(
                    Directory.GetCurrentDirectory())
                        !.Parent!.Parent!.FullName, _config["Path:Folder"] !);
        }
    }
}
