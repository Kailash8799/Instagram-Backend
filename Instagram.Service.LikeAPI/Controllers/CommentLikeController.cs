using Asp.Versioning;
using Instagram.Service.LikeAPI.Models.Dto;
using Instagram.Service.LikeAPI.Service.IService;
using Instagram.Services.LikeAPI.Utils;
using Microsoft.AspNetCore.Mvc;

namespace Instagram.Service.LikeAPI.Controllers {

    [Route("/api/v1/like-comment")]
    [ApiController]
    public class CommentLikeController : ControllerBase {

        private readonly ICommentLikeService _commentLikeService;
        public CommentLikeController(ICommentLikeService commentLikeService) {
            _commentLikeService = commentLikeService;
        }

        [ApiVersion("1.0")]
        //[Authorize]
        [HttpPost("like", Name = "AddLike")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult AddLike([FromBody] CommentLikeRequestDTO commentLikeRequestDTO) {
            _commentLikeService.LikeComment(commentLikeRequestDTO);
            var res = ApiResponseHelper.CreateResponse(200, "Liked", true, "");
            return StatusCode(200, res);
        }

        [ApiVersion("1.0")]
        //[Authorize]
        [HttpDelete("dislike", Name = "RemoveLike")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult RemoveLike([FromBody] CommentLikeRequestDTO commentLikeRequestDTO) {
            _commentLikeService.DisLikeComment(commentLikeRequestDTO);
            var res = ApiResponseHelper.CreateResponse(200, "DisLiked", true, "");
            return StatusCode(200, res);
        }
    }
}
