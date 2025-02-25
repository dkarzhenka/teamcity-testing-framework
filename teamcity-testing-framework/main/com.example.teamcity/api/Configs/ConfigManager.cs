using Microsoft.Extensions.Configuration;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace teamcity_testing_framework.main.com.example.teamcity.api.Configs
{
    public class ConfigManager
    {
        private static readonly string _configPath = "appsettings.json";
        private static readonly Lazy<ConfigManager> _instance = new Lazy<ConfigManager>(() => new ConfigManager());
        public IConfiguration Configuration { get; private set; }
        
        private ConfigManager()
        {
            Initialize();
        }

        public static ConfigManager ConfigInstance => _instance.Value;

        public static T GetProperty<T>(string path)
        {
            var value = ConfigInstance.Configuration[path] ?? throw new KeyNotFoundException($"Key {path} not found in config");
            return (T)Convert.ChangeType(value, typeof(T));
        }

        private void Initialize()
        {
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile(_configPath, optional: false, reloadOnChange: true)
                .Build();
            Configuration = config;
        }
    }
}
