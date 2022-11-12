using Microsoft.Extensions.Configuration;

namespace Module2Homework5.Configuration
{
    public class ConfigurationManager
    {
        private IConfigurationRoot _config;
        public ConfigurationManager()
        {
            _config = new ConfigurationBuilder().AddJsonFile($"configuration.json", true, true).Build();
        }

        public string? GetPath() => _config["Path:File"];
    }
}
