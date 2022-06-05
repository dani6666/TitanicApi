using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TitanicApi.Core.AppSettings;
using TitanicApi.Core.Interfaces;
using TitanicApi.Infrastructure;

[assembly: FunctionsStartup(typeof(TitanicApi.Startup))]

namespace TitanicApi;

public class Startup : FunctionsStartup
{
    public override void Configure(IFunctionsHostBuilder functionsHostBuilder)
    {
        FunctionsHostBuilderContext context = functionsHostBuilder.GetContext();

        var configurationBuilder = new ConfigurationBuilder()
            .SetBasePath(context.ApplicationRootPath)
            .AddJsonFile("appsettings.json")
            .AddEnvironmentVariables("AppSettings__");

        AddServices(functionsHostBuilder.Services, configurationBuilder.Build());
    }

    private static void AddServices(IServiceCollection services, IConfiguration configuration)
    {
        var settings = configuration.Get<AppSettings>();

        services.AddSingleton(_ => settings.AzureTableStorageSettings);
        services.AddSingleton<ITitanicDataAccess, TitanicDataAccess>();
    }
}
