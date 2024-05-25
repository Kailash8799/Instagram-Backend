using Asp.Versioning;
using Instagram.Service.NotificationAPI.Model.Dto;
using Instagram.Service.NotificationAPI.Service.IService;
using Instagram.Services.NotificationAPI.Utils;
using Microsoft.AspNetCore.Mvc;

namespace Instagram.Service.NotificationAPI.Controllers {

    [Route("/api/v1/notification")]
    [ApiController]
    public class EmailController : ControllerBase {

        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService) {
            _emailService = emailService;
        }

        [ApiVersion("1.0")]
        //[Authorize]
        [HttpPost("follow-email", Name = "SendFollowEmail")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult SendFollowEmail([FromBody] EmailDTO emailDTO) {
            _emailService.SendFollowEmail(emailDTO);
            var res = ApiResponseHelper.CreateResponse(200, "Email sent successfully", true, "");
            return StatusCode(200, res);
        }

        [ApiVersion("1.0")]
        //[Authorize]
        [HttpPost("newpost-email", Name = "NewPostEmail")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult NewPostEmail([FromBody] EmailDTO emailDTO) {
            _emailService.SendFollowEmail(emailDTO);
            var res = ApiResponseHelper.CreateResponse(200, "Email sent successfully", true, "");
            return StatusCode(200, res);
        }
    }
}
