using Asp.Versioning;
using Instagram.Service.LikeAPI.Models.Dto;
using Instagram.Service.LikeAPI.Service.IService;
using Instagram.Services.LikeAPI.Utils;
using Microsoft.AspNetCore.Mvc;

namespace Instagram.Service.LikeAPI.Controllers {

    [Route("/api/v1/like-post")]
    [ApiController]
    public class PostLikeController : ControllerBase {

        private readonly IPostLikeService _postLikeService;
        public PostLikeController(IPostLikeService postLikeService) {
            _postLikeService = postLikeService;
        }

        [ApiVersion("1.0")]
        //[Authorize]
        [HttpGet("get/{postId}", Name = "GetAllPostLike")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetAllPostLike(string postId) {
            List<PostLikeDTO> postlikes = _postLikeService.GetAllLikes(postId);
            var res = ApiResponseHelper.CreateResponse(200, "All Likes", true, postlikes);
            return StatusCode(200, res);
        }

        [ApiVersion("1.0")]
        //[Authorize]
        [HttpPost("like", Name = "AddPostLike")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult AddPostLike([FromBody] PostLikeRequestDTO postLikeRequestDTO) {
            _postLikeService.LikePost(postLikeRequestDTO);
            var res = ApiResponseHelper.CreateResponse(200, "Liked", true, "");
            return StatusCode(200, res);
        }

        [ApiVersion("1.0")]
        //[Authorize]
        [HttpDelete("dislike", Name = "RemovePostLike")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult RemovePostLike([FromBody] PostLikeRequestDTO postLikeRequestDTO) {
            _postLikeService.DisLikePost(postLikeRequestDTO);
            var res = ApiResponseHelper.CreateResponse(200, "DisLiked", true, "");
            return StatusCode(200, res);
        }
    }
}
