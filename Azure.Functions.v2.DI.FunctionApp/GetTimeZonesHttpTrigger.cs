using Azure.Functions.v2.DI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Azure.Functions.v2.DI.FunctionApp
{
    public static class GetTimeZonesHttpTrigger 
    {
        //This is public so that we can unit test. But are unit tests needed here as we can test service project instead. So it can be made private.
        public static IServiceProvider ServiceProvider { get; set; } = Bootstrap.ConfigureServices();

        [FunctionName("GetTimeZones")]
        public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "timezones")]HttpRequest req, ILogger log)
        {
            var serviceProvider = Bootstrap.ConfigureServices();
            
            log.LogInformation("GET TIMEZONES");

            var timeZoneService = ServiceProvider.GetService<ITimeZoneService>();
            var timeZones = await timeZoneService.GetTimeZones().ConfigureAwait(false);

            return new OkObjectResult(timeZones ?? new List<string>());
        }
    }
}
