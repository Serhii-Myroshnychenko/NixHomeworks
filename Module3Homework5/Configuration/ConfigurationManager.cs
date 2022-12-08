using Microsoft.Extensions.Configuration;
using Module3Homework5.Contracts;

namespace Module3Homework5.Configuration
{
    public class ConfigurationManager : IPathProvider
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
