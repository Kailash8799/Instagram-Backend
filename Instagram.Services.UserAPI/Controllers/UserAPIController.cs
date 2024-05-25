using Asp.Versioning;
using Instagram.Services.UserAPI.Models.Dto;
using Instagram.Services.UserAPI.Service.IService;
using Instagram.Services.UserAPI.Utils;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Instagram.Services.UserAPI.Controllers {

    [Route("/api/v1/user")]
    [ApiController]
    [ApiVersion("1.0")]
    public class UserAPIController : ControllerBase {

        private readonly IUserService _userService;
        public UserAPIController(IUserService userService) {
            _userService = userService;
        } 

        //[Authorize]
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public Task<IActionResult> GetProfile(string id) {
            try {
                if (string.IsNullOrWhiteSpace(id)) {
                    var result = ApiResponseHelper.CreateResponse(400, "Id is Invalid", false, "");
                    return Task.FromResult<IActionResult>(NotFound(result));
                }
            UserDTO? userDTO = _userService.GetProfile(id);
            if (userDTO == null) {
                var result = ApiResponseHelper.CreateResponse(400, "User not found", false, "");
                return Task.FromResult<IActionResult>(NotFound(result));
            }
            var response = ApiResponseHelper.CreateResponse(200, "User", true, userDTO);
            return Task.FromResult<IActionResult>(Ok(response));
                 
            } catch (Exception) {
                var response = ApiResponseHelper.CreateResponse(200, "Internal server error", false, "");
                return Task.FromResult<IActionResult>(StatusCode(StatusCodes.Status500InternalServerError,response));
            }
        }
        
        //[Authorize]
        [HttpPatch("update/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateProfile(string id, JsonPatchDocument<UserDTO> userPatchDTO) {
            if(id == null || userPatchDTO == null) {
                var result = ApiResponseHelper.CreateResponse(400, "Id or update data not provided", false, "");
                return BadRequest(result);
            }
            UserDTO? userDTO = _userService.GetProfile(id);
            if(userDTO == null) {
                var result = ApiResponseHelper.CreateResponse(400, "Update User not found", false, "");
                return BadRequest(result);
            }
            userPatchDTO.ApplyTo(userDTO,ModelState);
            if (!ModelState.IsValid) {
                var result = ApiResponseHelper.CreateResponse(400, "Some field are not valid", false, "");
                return BadRequest(result);
            }
            string res = await _userService.UpdateProfile(userDTO);
            if(string.IsNullOrEmpty(res)) {
                var result = ApiResponseHelper.CreateResponse(400, "Profile not updated", false, "");
                return BadRequest(result);
            }
            var response = ApiResponseHelper.CreateResponse(200, "Profile updated successfully", true, res);
            return Ok(response);
        }
    }
}
