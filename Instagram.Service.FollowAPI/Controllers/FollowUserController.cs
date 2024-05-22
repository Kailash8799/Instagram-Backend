using Asp.Versioning;
using Instagram.Service.FollowAPI.Models.Dto;
using Instagram.Service.FollowAPI.Service.IService;
using Instagram.Services.FollowAPI.Utils;
using Microsoft.AspNetCore.Mvc;

namespace Instagram.Service.FollowAPI.Controllers {

    [Route("/api/v1/follow-user")]
    [ApiController]
    public class FollowUserController : ControllerBase {
        private readonly IFollowService _followService;
        public FollowUserController(IFollowService followService) {
            _followService = followService;
        }

        [ApiVersion("1.0")]
        //[Authorize]
        [HttpGet("get-followers/{userId}", Name = "GetFollowers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetFollowers(string userId) {
            List<FollowResponseDTO> followers = _followService.GetFollowersByUserId(userId);
            var res = ApiResponseHelper.CreateResponse(200, "All followers", true, followers);
            return StatusCode(200, res);
        }
        
        [ApiVersion("1.0")]
        //[Authorize]
        [HttpGet("get-following/{userId}", Name = "GetFollowing")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetFollowing(string userId) {
            List<FollowResponseDTO> followings = _followService.GetFollowingByUserId(userId);
            var res = ApiResponseHelper.CreateResponse(200, "All followings", true, followings);
            return StatusCode(200, res);
        }

        [ApiVersion("1.0")]
        //[Authorize]
        [HttpPost("follow", Name = "FollowUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult FollowUser([FromBody] FollowRequestDTO followRequestDTO) {
            if(followRequestDTO.FolllowerId == followRequestDTO.FollowingId) {
                throw new Exception("You can't not follow yourself");
            }
            _followService.FollowUser(followRequestDTO);
            var res = ApiResponseHelper.CreateResponse(200, "Followed", true, "");
            return StatusCode(200, res);
        }

        [ApiVersion("1.0")]
        //[Authorize]
        [HttpPost("unfollow", Name = "UnFollowUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UnFollowUser([FromBody] FollowRequestDTO followRequestDTO) {
            if (followRequestDTO.FolllowerId == followRequestDTO.FollowingId) {
                throw new Exception("You can't not unfollow yourself");
            }
            _followService.UnFollowUser(followRequestDTO);
            var res = ApiResponseHelper.CreateResponse(200, "UnFollowed", true, "");
            return StatusCode(200, res);
        }
    }
}
