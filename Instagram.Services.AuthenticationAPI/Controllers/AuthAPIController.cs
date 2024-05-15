using Asp.Versioning;
using Instagram.Services.AuthenticationAPI.Models.Dto;
using Instagram.Services.AuthenticationAPI.Service.IService;
using Instagram.Services.AuthenticationAPI.Utils;
using Microsoft.AspNetCore.Mvc;

namespace Instagram.Services.AuthenticationAPI.Controllers {

    [Route("/api/v1/auth")]
    [ApiController]
    [ApiVersion("1.0")]
    public class AuthAPIController : ControllerBase {

        private readonly IAuthService _authService;
        public AuthAPIController(IAuthService authService) {
            _authService = authService;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost("signin")]
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
                var responce = ApiResponseHelper.CreateResponse(500, "Internal server error", false, 0);
                return BadRequest(responce);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost("signup")]
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
            var responce = ApiResponseHelper.CreateResponse(500, "Internal server error", false, 0);
            return BadRequest(responce);
            }
        }

    }
}
