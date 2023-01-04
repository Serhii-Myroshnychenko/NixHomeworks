using Microsoft.Extensions.Configuration;
using Module4Homework3.Contracts;

namespace Module4Homework3.Managers
{
    public class ConfigurationManager : IPathProvider
    {
        private readonly IConfigurationRoot _config;
        public ConfigurationManager()
        {
            _config = new ConfigurationBuilder().AddJsonFile($"configuration.json", true, true).Build();
        }

        public string GetConnectionString() => _config["Path:ConnectionString"] !;
    }
}
