using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TitanicApi.Core.Interfaces;
using TitanicApi.Infrastructure;

[assembly: FunctionsStartup(typeof(TitanicApi.Startup))]

namespace TitanicApi;

public class Startup : FunctionsStartup
{
    public override void Configure(IFunctionsHostBuilder builder)
    {
        builder.Services.AddSingleton<ITitanicDataAccess, TitanicDataAccess>();
    }

    public override void ConfigureAppConfiguration(IFunctionsConfigurationBuilder builder)
    {
        FunctionsHostBuilderContext context = builder.GetContext();

        builder.ConfigurationBuilder
            .SetBasePath(context.ApplicationRootPath)
            .AddJsonFile("appsettings.json")
            .AddEnvironmentVariables(prefix: "AppSettings_");
    }
}
