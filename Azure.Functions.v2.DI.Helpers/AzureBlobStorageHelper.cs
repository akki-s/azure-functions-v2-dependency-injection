using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Threading.Tasks;

namespace Azure.Functions.v2.DI.Helpers
{
    public class AzureBlobStorageHelper : IAzureBlobStorageHelper
    {
        private static CloudBlobClient _blobClient;
        private const string StorageConnectionString = "UseDevelopmentStorage=true";

        public AzureBlobStorageHelper()
        {
            _blobClient = CreateCloudBlobClient();
        }

        public async Task<string> DownloadBlobContent(string containerName, string blobName)
        {
            var blob = await GetCloudBlockBlobAsync(containerName, blobName)
                           .ConfigureAwait(false);

            if (null == blob)
                return string.Empty;

            return await blob.DownloadTextAsync().ConfigureAwait(false);
        }

        private static CloudBlobClient CreateCloudBlobClient()
        {
            var storageAccount = CloudStorageAccount.Parse(StorageConnectionString);
            return storageAccount.CreateCloudBlobClient();
        }

        private static async Task<CloudBlockBlob> GetCloudBlockBlobAsync(string containerName, string blobName)
        {
            var container = _blobClient.GetContainerReference(containerName);

            await container.CreateIfNotExistsAsync()
                           .ConfigureAwait(false);

            var blob = container.GetBlockBlobReference(blobName);
            return blob;
        }
    }
}
