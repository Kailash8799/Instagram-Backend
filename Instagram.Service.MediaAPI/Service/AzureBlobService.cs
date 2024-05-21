using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Instagram.Service.MediaAPI.Models.Dto;
using Instagram.Service.MediaAPI.Service.IService;

namespace Instagram.Service.MediaAPI.Service {
    public class AzureBlobService : IAzureBlobService {

        private readonly BlobServiceClient _blobClient;
        private readonly BlobContainerClient _containerClient;
        private readonly string _containerName;
        public AzureBlobService(IConfiguration configuration) {
            var connectionString = configuration.GetConnectionString("AzureStorage");
            _containerName = configuration.GetValue<string>("AzureStorage:ContainerName") ?? "";
            _blobClient = new BlobServiceClient(connectionString);
            _containerClient = _blobClient.GetBlobContainerClient(_containerName);
        }

        public async Task<List<string>> UploadFiles(List<IFormFile> files) {
            var azureResponse = new List<string>();
            foreach (var file in files) {
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                string contentType = file.ContentType;
                using (var memoryStream = new MemoryStream()) {
                    await file.CopyToAsync(memoryStream);
                    memoryStream.Position = 0;
                    BlobHttpHeaders blobHttpHeaders = new() {
                        ContentType = contentType,
                    };
                    BlobClient blobClient = _containerClient.GetBlobClient(fileName);
                    await blobClient.UploadAsync(memoryStream, overwrite: true, cancellationToken: default);
                    await blobClient.SetHttpHeadersAsync(blobHttpHeaders, cancellationToken: default);
                    azureResponse.Add(blobClient.Uri.AbsoluteUri.ToString());
                }
            };
            return azureResponse;
        }

        public async Task<List<string>> GetUploadedFiles() {
            var items = new List<string>();
            await foreach (BlobItem blobItem in _containerClient.GetBlobsAsync()) {
                Uri blobUri = new(_containerClient.Uri, _containerName + "/" + blobItem.Name);
                items.Add(blobUri.ToString());
            }
            return items;
        }

        public async Task<bool> DeleteFiles(DeleteFileDTO deleteFileDTO) {
            foreach (var file in deleteFileDTO.filesToDelete) {
                string blobName = GetBlobNameFromUrl(file);
                Console.WriteLine(blobName);
                await _containerClient.DeleteBlobIfExistsAsync(blobName);
            }
            return true;
        }

        public static string GetBlobNameFromUrl(string url) {
            string[] parts = url.Split('/');
            if (parts.Length >= 2) {
                return parts[^1];
            } else {
                return "Invalid URL";
            }
        }
    }
}
