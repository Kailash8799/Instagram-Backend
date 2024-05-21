using Azure.Storage.Blobs.Models;
using Instagram.Service.MediaAPI.Models.Dto;

namespace Instagram.Service.MediaAPI.Service.IService {
    public interface IAzureBlobService {
        Task<List<string>> UploadFiles(List<IFormFile> files);

        Task<List<string>> GetUploadedFiles();
        Task<bool> DeleteFiles(DeleteFileDTO files);
    }
}
