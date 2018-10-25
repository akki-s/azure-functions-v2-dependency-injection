using System;
using System.Threading.Tasks;

namespace Azure.Functions.v2.DI.Helpers
{
    public interface IAzureBlobStorageHelper
    {
        Task<string> DownloadBlobContent(string containerName, string blobName);
    }
}
