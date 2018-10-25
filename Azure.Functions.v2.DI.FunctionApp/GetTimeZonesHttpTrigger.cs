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

namespace Azure.Functions.v2.DI.FunctionApp
{
    public static class GetTimeZonesHttpTrigger 
    {

        [FunctionName("GetTimeZones")]
        public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "timezones")]HttpRequest req, TraceWriter log)
        {
            var serviceProvider = Bootstrap.Build();
            
            var timeZoneService = serviceProvider.GetService<ITimeZoneService>();
            var timeZones = await timeZoneService.GetTimeZones().ConfigureAwait(false);

            return new OkObjectResult(timeZones ?? new List<string>());
        }
    }
}
