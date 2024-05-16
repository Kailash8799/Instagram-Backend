using Asp.Versioning;
using Instagram.Services.UserAPI.Models.Dto;
using Instagram.Services.UserAPI.Service.IService;
using Instagram.Services.UserAPI.Utils;
using Microsoft.AspNetCore.Mvc;

namespace Instagram.Services.UserAPI.Controllers {

    [Route("/api/v1/auth")]
    [ApiController]
    [ApiVersion("1.0")]
    public class AuthAPIController : ControllerBase {

        private readonly IAuthService _authService;
        public AuthAPIController(IAuthService authService) {
            _authService = authService;
        }

        [HttpPost("signin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> SignIn([FromBody] LoginRequestDTO loginRequestUser) {
            try {
                LoginResponseDTO res = await _authService.Login(loginRequestUser);
                if (res.User == null || res.Token == "") {
                    var result = ApiResponseHelper.CreateResponse(400, "Invalid credentials", false, res);
                    return BadRequest(result);
                } else {
                    var result = ApiResponseHelper.CreateResponse(200, "Login successfull", false, res);
                    return Ok(result);
                }
            } catch {
                var response = ApiResponseHelper.CreateResponse(500, "Internal server error", false, 0);
                return BadRequest(response);
            }
        }

        [HttpPost("signup")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> SignUp([FromBody] RegistrationRequestDTO registrationUser) {
            try {
                RegistrationResponseDTO res = await _authService.Register(registrationUser);
                if(res.success) {
                    var result = ApiResponseHelper.CreateResponse(201, res.message, true, res);
                    return Ok(result);
                } else {
                    var result = ApiResponseHelper.CreateResponse(400, res.message, false, res);
                    return BadRequest(result);
                }
            } catch {
            var response = ApiResponseHelper.CreateResponse(500, "Internal server error", false, 0);
            return BadRequest(response);
            }
        }

        // this is not implemented  // future use
        [HttpPost("resetpassword")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> ResetPassword([FromBody] RegistrationRequestDTO registrationUser) {
            try {
                RegistrationResponseDTO res = await _authService.Register(registrationUser);
                if (res.success) {
                    var result = ApiResponseHelper.CreateResponse(201, res.message, true, res);
                    return Ok(result);
                } else {
                    var result = ApiResponseHelper.CreateResponse(400, res.message, false, res);
                    return BadRequest(result);
                }
            } catch {
                var response = ApiResponseHelper.CreateResponse(500, "Internal server error", false, 0);
                return BadRequest(response);
            }
        }

    }
}
