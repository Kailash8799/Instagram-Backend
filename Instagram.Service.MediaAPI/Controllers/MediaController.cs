using Asp.Versioning;
using Instagram.Service.MediaAPI.Models.Dto;
using Instagram.Service.MediaAPI.Service.IService;
using Instagram.Services.MediaAPI.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Instagram.Service.MediaAPI.Controllers {

    [Route("/api/v1/media")]
    [ApiController] 
    public class MediaController : ControllerBase {

        private readonly IAzureBlobService _azureBlobService;

        public MediaController(IAzureBlobService azureBlobService) {
            _azureBlobService = azureBlobService;
        }

        // get all files
        [ApiVersion("1.0")]
        //[Authorize]
        [HttpGet("get-files",Name = "GetAllFiles")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllFiles() {
            var response = await _azureBlobService.GetUploadedFiles();
            var res = ApiResponseHelper.CreateResponse(200, "All files", true, response);
            return Ok(res);
        }

        // upload files api
        [ApiVersion("1.0")]
        //[Authorize]
        [HttpPost("upload-files", Name = "UploadFiles")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UploadFiles(IFormFileCollection files, CancellationToken cancellationToken) {
            var result = await _azureBlobService.UploadFiles([.. files]);
            var res = ApiResponseHelper.CreateResponse(200, "Files uploaded successfully", true, result);
            return Ok(res);
        }

        // delete files api 
        [ApiVersion("1.0")]
        //[Authorize]
        [HttpDelete("delete-files", Name = "DeleteFiles")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteFiles([FromBody] DeleteFileDTO deleteFileDTO) {
            await _azureBlobService.DeleteFiles(deleteFileDTO);
            var res = ApiResponseHelper.CreateResponse(200, "File deleted successfully", true, "");
            return Ok(res);
        }
    }
}
