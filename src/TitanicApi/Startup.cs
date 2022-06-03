using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
}
