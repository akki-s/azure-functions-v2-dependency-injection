using System.Collections.Generic;
using System.Threading.Tasks;

namespace Azure.Functions.v2.DI.Services
{
    public interface ITimeZoneService
    {
        Task<IEnumerable<string>> GetTimeZones();
    }
}
