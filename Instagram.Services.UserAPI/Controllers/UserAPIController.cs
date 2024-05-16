using Asp.Versioning;
using Instagram.Services.UserAPI.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Instagram.Services.UserAPI.Controllers {

    [Route("/api/v1/user")]
    [ApiController]
    [ApiVersion("1.0")]
    public class UserAPIController : ControllerBase {

        //[Authorize]
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProfile(string id) {

            var response = ApiResponseHelper.CreateResponse(200, "", true, "");
            return Ok(response);
        }
        //[Authorize]
        [HttpPut("update/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateProfile(string id) {

            var response = ApiResponseHelper.CreateResponse(200, "", true, "");
            return Ok(response);
        }
        //[Authorize]
        [HttpPatch("update/picture/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateProfilePicture(string id) {

            var response = ApiResponseHelper.CreateResponse(200, "", true, "");
            return Ok(response);
        }
        //[Authorize]
        [HttpPatch("remove/picture/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> RemoveProfilePicture(string id) {

            var response = ApiResponseHelper.CreateResponse(200, "", true, "");
            return Ok(response);
        }
    }
}
