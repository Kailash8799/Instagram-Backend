using Asp.Versioning;
using Instagram.Service.CommentAPI.Service.IService;
using Instagram.Services.CommentAPI.Models.Dto;
using Instagram.Services.CommentAPI.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Instagram.Services.CommentAPI.Controllers {

    [Route("/api/v1/comment")]
    [ApiController]
    public class CommentController : ControllerBase {
        
        private readonly ICommentService _commentService;
        public CommentController(ICommentService commentService) {
            _commentService = commentService;
        }

        [ApiVersion("1.0")]
        //[Authorize]
        [HttpPost("add", Name = "AddComment")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddComment(CommentRequestDTO commentRequestDTO) {
            CommentResponseDTO comment = await _commentService.AddComment(commentRequestDTO);
            var res = ApiResponseHelper.CreateResponse(201, "Comment", true, comment);
            return StatusCode(201,res);
        }

        [ApiVersion("1.0")]
        //[Authorize]
        [HttpGet("get-by-post/{postId}", Name = "GetCommentByPostId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetCommentByPostId(string postId) {
             List<CommentResponseDTO> comments = _commentService.GetCommentByPostId(postId);
             var res = ApiResponseHelper.CreateResponse(200, "Comments", true, comments);
             return Ok(res);
        }

        [ApiVersion("1.0")]
        //[Authorize]
        [HttpGet("get-by-user/{userId}", Name = "GetCommentByUserId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetCommentByUserId(string userId) {
            List<CommentResponseDTO> comments = _commentService.GetCommentByUserId(userId);
            var res = ApiResponseHelper.CreateResponse(200, "Comments", true, comments);
            return Ok(res);
        }

        [ApiVersion("1.0")]
        //[Authorize]
        [HttpDelete("delete-by-id/{commentId}", Name = "DeleteCommentByCommentId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteCommentByCommentId(string commentId) {
            _commentService.DeleteCommentByCommentId(commentId);
            var res = ApiResponseHelper.CreateResponse(200, "Comment deleted successfully", true, "");
            return Ok(res);
        }

        [ApiVersion("1.0")]
        //[Authorize]
        [HttpDelete("delete-by-user/{userId}", Name = "DeleteCommentByUserId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteCommentByUserId(string userId) {
            _commentService.DeleteCommentByUserId(userId);
            var res = ApiResponseHelper.CreateResponse(200, "Comments deleted successfully", true, "");
            return Ok(res);
        }

        [ApiVersion("1.0")]
        //[Authorize]
        [HttpDelete("delete-by-post/{postId}", Name = "DeleteCommentByPostId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteCommentByPostId(string postId) {
             _commentService.DeleteCommentByPostId(postId);
            var res = ApiResponseHelper.CreateResponse(200, "Comments deleted successfully", true, "");
            return Ok(res);
        }
    }
}
