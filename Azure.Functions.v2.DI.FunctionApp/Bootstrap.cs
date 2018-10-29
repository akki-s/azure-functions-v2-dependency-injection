using Azure.Functions.v2.DI.Helpers;
using Azure.Functions.v2.DI.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using Microsoft.Extensions.Logging;

namespace Azure.Functions.v2.DI.FunctionApp
{
    public static class Bootstrap
    {
        public static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection()
                    .AddTransient<ITimeZoneService, TimeZoneService>()
                    .AddTransient<IAzureBlobStorageHelper, AzureBlobStorageHelper>();

            return services.BuildServiceProvider();
        }
    }
}
