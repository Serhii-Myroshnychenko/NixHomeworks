using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Module5Homework1;
using Module5Homework1.Config;
using Module5Homework1.Contracts;
using Module5Homework1.Services;

void ConfigureServices(ServiceCollection serviceCollection, IConfiguration configuration)
{
    serviceCollection.AddOptions<ApiOptions>().Bind(configuration.GetSection("Api"));
    serviceCollection
        .AddLogging(configure => configure.AddConsole())
        .AddHttpClient()
        .AddTransient<IInternalHttpClientService, InternalHttpClientService>()
        .AddTransient<IUserService, UserService>()
        .AddTransient<IAuthService, AuthService>()
        .AddTransient<IResourceService, ResourceService>()
        .AddTransient<App>();
}

IConfiguration configuration = new ConfigurationBuilder()
    .AddJsonFile("configuration.json")
    .Build();

var serviceCollection = new ServiceCollection();
ConfigureServices(serviceCollection, configuration);
var provider = serviceCollection.BuildServiceProvider();

var app = provider.GetService<App>();
await app!.Start();