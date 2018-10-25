using Azure.Functions.v2.DI.Helpers;
using Azure.Functions.v2.DI.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Azure.Functions.v2.DI.FunctionApp
{
    public static class Bootstrap
    {
        public static IServiceProvider Build()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddTransient<ITimeZoneService, TimeZoneService>();
            services.AddTransient<IAzureBlobStorageHelper, AzureBlobStorageHelper>();

            return services.BuildServiceProvider();
        }
    }
}
