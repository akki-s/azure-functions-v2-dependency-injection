using Azure.Functions.v2.DI.Helpers;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Azure.Functions.v2.DI.Services
{
    public class TimeZoneService : ITimeZoneService
    {
        private const string ContainerName = "azfnv2demo";
        private const string FileName = "timezones.json";

        private readonly IAzureBlobStorageHelper _azureBlobStorageHelper;

        public TimeZoneService(IAzureBlobStorageHelper azureBlobStorageHelper)
        {
            _azureBlobStorageHelper = azureBlobStorageHelper;;
        }

        public async Task<IEnumerable<string>> GetTimeZones()
        {
            var jsonContent = await _azureBlobStorageHelper.DownloadBlobContent(ContainerName, FileName).ConfigureAwait(false);
            return string.IsNullOrEmpty(jsonContent) ? null : JsonConvert.DeserializeObject<IEnumerable<string>>(jsonContent);
        }
    }
}
