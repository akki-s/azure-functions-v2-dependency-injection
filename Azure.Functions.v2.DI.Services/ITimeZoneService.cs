using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Azure.Functions.v2.DI.Services
{
    public interface ITimeZoneService
    {
        //ILogger Log { get; set; }
        Task<IEnumerable<string>> GetTimeZones();
    }
}
