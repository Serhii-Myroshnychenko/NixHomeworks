using Microsoft.Extensions.Configuration;

namespace Module3Homework7.Configurations
{
    public class ConfigurationHandler
    {
        private readonly IConfigurationRoot _config;
        public ConfigurationHandler()
        {
            _config = new ConfigurationBuilder().AddJsonFile($"configuration.json", true, true).Build();
        }

        public string GetPath()
        {
            return 
                 Directory.GetParent(
                     Directory.GetCurrentDirectory())
                         !.Parent!.Parent!.FullName + _config["Path:Folder"];
        }
        public int GetCountOfLogs() => int.Parse(_config["Count:N"]);
    }
}
